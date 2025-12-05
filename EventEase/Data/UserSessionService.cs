using EventEase.Models;

namespace EventEase.Data
{
    public class UserSessionService
    {
        private readonly List<EventModel> events = new();

        public UserSessionService()
        {
            // Datos simulados
            events.Add(new EventModel { Name="Conferencia Tech", Date=DateTime.Now.AddDays(5), Location="Barcelona" });
            events.Add(new EventModel { Name="Networking Empresarial", Date=DateTime.Now.AddDays(10), Location="Madrid" });
        }

        public IEnumerable<EventModel> GetEvents() => events;

        public EventModel? GetEventById(int id) =>
            id > 0 && id <= events.Count ? events[id - 1] : null;

        public void RegisterUser(int eventId, RegisterModel user)
        {
            var ev = GetEventById(eventId);
            if (ev != null)
            {
                ev.RegisteredUsers.Add(user);
            }
        }
    }
}
