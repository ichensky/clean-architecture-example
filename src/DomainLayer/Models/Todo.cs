using DomainLayer.SeedCore;

namespace DomainLayer.Models
{
    public class Todo : IAggregateRootEntity
    {
        public Todo() { }

        public Todo(string title)
        {
            Id = Guid.NewGuid();
            Date = DateTime.UtcNow;
            SetTitle(title);
        }

        public Guid Id { get; protected set; }

        public string Title { get; protected set; }

        public DateTime Date { get; protected set; }

        public DateTime UpdateDate { get; protected set; }

        public void UpdateTitle(string title)
        {
            SetTitle(title);
        }

        private void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new BusinessException("Title cannot be empty");
            }

            if (title.Length > 100)
            {
                throw new BusinessException("Title cannot be longer than 100 characters");
            }

            Title = title;
        }
    }
}
