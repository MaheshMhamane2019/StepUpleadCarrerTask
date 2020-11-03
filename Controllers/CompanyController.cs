using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StepUpLeadCareersTask.Models;
//using Microsoft.Extensions.Primitives.StringValues;

namespace StepUpLeadCareersTask.Controllers
{
    public class CompanyController : Controller
    {
        private readonly CompanyContext _context;
        private readonly IConverter _converter;

        public CompanyController(CompanyContext context, IConverter converter)
        {
            _context = context;
            _converter = converter;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            return View(await _context.Comapanys.ToListAsync());
        }


        // GET: Employee/Create
        public IActionResult Add(int id = 0)
        {
            if (id == 0)
                return View(new Company());
            else
                return View(_context.Comapanys.Find(id));
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("FirstName,LastName,Email,CompanyName,CompanySize,JobRole,JobDepartment,Phone,Country,UserIpAddress,UserBrowserDetails,UserOsInfroamtion,LinkPageUrl")] Company company)
        {
            var remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress;
            var userAgent = Request.Headers["User-Agent"];
            var osNameAndVersion = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
            company.UserOsInfroamtion = osNameAndVersion;
            company.UserIpAddress = remoteIpAddress.ToString();
            company.UserBrowserDetails = userAgent.ToString();


            if (ModelState.IsValid)
            {
                if (company.CompanyId == 0)
                    _context.Add(company);
                else
                    _context.Update(company);
                await _context.SaveChangesAsync();
                //return Redirect("~/Company/CreatePDF");
                return Redirect("~/Home/Welcome");

            }
            return Redirect("~/Home/Welcome");
        }
        [HttpGet]
        public IActionResult CreatePDF()
        {
            var emp = _context.Comapanys.OrderByDescending(p=> p.CompanyId);
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>This is the generated PDF report!!!</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>FirstName</th>
                                        <th>LastName</th>
                                        <th>Email</th>
                                        <th>CompanyName</th>
                                        <th>CompanySize</th>
                                        <th>Country</th>
                                        <th>Phone</th>
                                        <th>JobRole</th>
                                        <th>JobDepartment</th>
                                        <th>UserBrowserDetails</th>
                                        <th>UserIpAddress</th>
                                        <th>UserOsInfroamtion</th>
                                    </tr>");
            foreach (var employees in emp)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                  </tr>", employees.FirstName, employees.LastName, employees.Email, employees.CompanyName, employees.CompanySize
                                  , employees.Country, employees.Phone, employees.JobRole, employees.JobDepartment, employees.UserBrowserDetails,
                                  employees.UserIpAddress, employees.UserOsInfroamtion
                );
            }
            sb.Append(@"
                                </table>
                            </body>
                        </html>"
            ).ToString();
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                Out = @"D:\PDFCreator\Employee_Report.pdf"
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = sb.ToString(),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            _converter.Convert(pdf);
            return Redirect("~/Home/Welcome");
        }
      
        //GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var company = await _context.Comapanys.FindAsync(id);
            _context.Comapanys.Remove(company);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
