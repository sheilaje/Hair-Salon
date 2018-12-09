using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {

    [HttpGet("/stylists")]
    public ActionResult Index()
    {
      List<Stylist> allStylists = Stylist.GetAll();
      return View(allStylists);
    }

    [HttpGet("/stylists/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/stylists")]
    public ActionResult Create(string name)
    {
      Stylist newStylist = new Stylist(name);
      newStylist.Save();
      List<Stylist> allStylists = Stylist.GetAll();
      return RedirectToAction("Index");
    }

    [HttpGet("/stylists/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist selectedStylist = Stylist.Find(id);
      List<Client> stylistClientsList= selectedStylist.GetClient();
      model.Add("stylist", selectedStylist);
      model.Add("client", stylistClientsList);
      return View(model);
    }

    [HttpPost("/stylists/{stylistId}/clients")]
    public ActionResult Create(int stylistId, string clientName)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist foundStylist = Stylist.Find(stylistId);
      Client newClient = new Client(clientName, stylistId);
      newClient.Save();
      List<Client> clientList = foundStylist.GetClient();
      model.Add("client", clientList);
      model.Add("stylist", foundStylist);
      return View("Show", model);
    }
  }
}
