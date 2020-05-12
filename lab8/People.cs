namespace z1
{
    class People
    {
        Person[] data;
        public People(int kolvo)
        {
            data = new Person[kolvo];
        }
        public Person this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }
    }
}
