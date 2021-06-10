namespace MyBlazorSampleApp.ForLearning.Helpers
{
    public delegate void PersonInfoHandler(Person person);
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; }
        public event PersonInfoHandler PersonInfoChanged;
        public void SetName(string name)
        {
            Name = name;
            PersonInfoChanged?.Invoke(this);
        }
        public void SetAge(int age)
        {
            Age = age;
            PersonInfoChanged?.Invoke(this);
        }
        public void SetGender(int gender)
        {
            Gender = gender;
            PersonInfoChanged?.Invoke(this);
        }
    }
}
