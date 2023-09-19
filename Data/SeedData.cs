using System.Text.Json;
using test.web.Models;

namespace test.web.Data;

public static class SeedData
{
    public static async Task LoadEventData(TestContext context)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

         //Vill endast ladda om databsens tabell är tom...
        if(context.Events.Any()) return;

         //Läsa in json datat...
        var json = System.IO.File.ReadAllText("Data/json/events.json");
        
        //Konvertera json-objekten till en lista av Kurs-objekt...
        var events = JsonSerializer.Deserialize<List<Event>>(json, options);

        if(events is not null && events.Count > 0)
        {
            await context.Events.AddRangeAsync(events);
            await context.SaveChangesAsync();
        }
    }

    public static async Task LoadMemberData(TestContext context)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        if(context.Members.Any()) return;

        var json = System.IO.File.ReadAllText("Data/json/members.json");
        var members = JsonSerializer.Deserialize<List<Member>>(json, options);

        if (members is not null && members.Count > 0)
        {
            await context.Members.AddRangeAsync(members);
            await context.SaveChangesAsync();
        }
    }

    public static async Task LoadMemberEventData(TestContext context)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        if(context.MemberEvent.Any()) return;

        var json = System.IO.File.ReadAllText("Data/json/memberevent.json");
        var members = JsonSerializer.Deserialize<List<MemberEvent>>(json, options);

        if (members is not null && members.Count > 0)
        {
            await context.MemberEvent.AddRangeAsync(members);
            await context.SaveChangesAsync();
        }
    }
}
