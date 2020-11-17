namespace z1
{
    interface IAmPerson : IData<int>
    {
        string Name { get; }
        string Surname { get; }
        string Adress { get; }
    }
}
