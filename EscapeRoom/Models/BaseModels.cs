using System;

namespace EscapeRoom.Models
{
    // EN TEMEL SINIF
    public abstract class GameObject
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public GameObject(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }

    // ETKİLEŞİMLİ NESNELER SINIFI
    public abstract class InteractableItem : GameObject
    {
        public bool IsLocked { get; protected set; }

        public InteractableItem(string name, string description, bool isLocked)
            : base(name, description)
        {
            IsLocked = isLocked;
        }

        public abstract void Interact();
    }
}
