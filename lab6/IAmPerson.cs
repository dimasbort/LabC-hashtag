namespace z1
{
    interface IAmPerson : IData<int>
    {
        string Name { get; set; }
        string Surname { get; set; }
        string Adress { get; set; }
    }
}
