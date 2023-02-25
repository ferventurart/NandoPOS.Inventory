namespace Domain.Inventories;

public class Store
{
    public Store(string name, string address, string phoneNumber, string manager, string email)
    {
        Name = name;
        Address = address;
        PhoneNumber = phoneNumber;
        Manager = manager;
        Email = email;
        Active = true;
    }

    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Address { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public string Manager { get; set; }

    public bool Active { get; set; }

    public void ChangeStatus() => Active = !Active;

    public void ChangeName(string name)
    {
        if (!string.IsNullOrWhiteSpace(name) && Name != name)
        {
            Name = name;
        }
    }

    public void ChangeAddress(string address)
    {
        if (!string.IsNullOrWhiteSpace(address) && Address != address)
        {
            Address = address;
        }
    }

    public void ChangePhoneNumber(string phoneNumber)
    {
        if (!string.IsNullOrWhiteSpace(phoneNumber) && PhoneNumber != phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }
    }

    public void ChangeEmail(string email)
    {
        if (!string.IsNullOrWhiteSpace(email) && Email != email)
        {
            Email = email;
        }
    }

    public void ChangeManager(string manager)
    {
        if (!string.IsNullOrWhiteSpace(manager) && Manager != manager)
        {
            Manager = manager;
        }
    }
}
