using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace HairSalon.Objects
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        List<Stylist> AllStylists = Stylist.GetAll();
        return View["index.cshtml", AllStylists];
      };
      Post["/stylist/new"] = _ => {
        Stylist newStylist = new Stylist(Request.Form["stylist-name"]);
        newStylist.Save();
        return View["success.cshtml"];
      };
      Get["/stylists/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var SelectedStylist = Stylist.Find(parameters.id);
        var StylistClients = SelectedStylist.GetClients();
        model.Add("stylist", SelectedStylist);
        model.Add("clients", StylistClients);
        return View["stylists.cshtml", model];
      };
      Post["/client/new"] = _ => {
        Client newClient = new Client(Request.Form["client-name"], Request.Form["client-stylist"]);
        newClient.Save();
        return View["success.cshtml"];
      };
      Get["stylist/edit/{id}"] = parameters => {
        Stylist SelectedStylist = Stylist.Find(parameters.id);
        return View["stylist_edit.cshtml", SelectedStylist];
      };
      Patch["stylist/edit/{id}"] = parameters => {
        Stylist SelectedStylist = Stylist.Find(parameters.id);
        SelectedStylist.Update(Request.Form["stylist-name"]);
        return View["success.cshtml"];
      };
      Get["stylist/delete/{id}"] = parameters => {
        Stylist SelectedStylist = Stylist.Find(parameters.id);
        return View["stylist_delete.cshtml", SelectedStylist];
      };
      Delete["stylist/delete/{id}"] = parameters => {
        Stylist SelectedStylist = Stylist.Find(parameters.id);
        SelectedStylist.Delete();
        return View["success.cshtml"];
      };
      Get["client/{id}"] = parameters => {
        var SelectedClient = Client.Find(parameters.id);
        return View["client.cshtml", SelectedClient];
      };
      Patch["client/{id}"] = parameters => {
        Client SelectedClient = Client.Find(parameters.id);
        SelectedClient.Update(Request.Form["client-name"]);
        return View["success.cshtml"];
      };
      Delete["client/delete/{id}"] = parameters => {
      Client SelectedClient = Client.Find(parameters.id);
      SelectedClient.Delete();
      return View["success.cshtml"];
      };
    }
  }
}
