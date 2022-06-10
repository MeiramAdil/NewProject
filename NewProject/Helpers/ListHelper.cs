using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Encodings.Web;

namespace NewProject.Helpers
{
  public static class ListHelper
  {
    public static List<string> cities { get; set; }
    public static HtmlString CreateList(this IHtmlHelper html, List<string> items)
    {
      cities = items;
      string result = "<ul>";
      foreach(string item in items)
      {
        result = $"{result}<li>{item}</li>";
      }
      result = $"{result}</ul>";
      return new HtmlString(result);
    }
    public static HtmlString CreateListTagHelper(this IHtmlHelper html, List<string> items)
    {
      cities = items;
      TagBuilder ul = new TagBuilder("ul");
      foreach(string item in items)
      {
        TagBuilder li =new TagBuilder("li");
        li.InnerHtml.Append(item);
        ul.InnerHtml.AppendHtml(li);
      }
      ul.Attributes.Add("class", "itemList");
      var writer = new StringWriter();
      ul.WriteTo(writer, HtmlEncoder.Default);
      return new HtmlString(writer.ToString());
    }

    public static void AddToList(this IHtmlHelper html, string city)
    {
      cities.Add(city);
      CreateList(html, cities);
    }
    //public static HtmlString Create(this IHtmlHelper html)
    //{
    //  string result = "<form method=\"post\" action=\"~/ City / Create\">< p >";
       
   
    //       < lable > Name for city </ lable >
      
    //          < input type = "text" name = "name" />
      
    //      </ p >
      
    //      < p >
      
    //          < lable > Population </ lable >
      
    //          < input type = "number" name = "population" />
      
    //      </ p >
      
    //      < input type = "submit" value = "Submit" />
    //  </ form >
    //  "
    //}
  }
}
