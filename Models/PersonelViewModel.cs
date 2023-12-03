namespace ETS.UI.Models
{
    public class PersonelViewModel
    {
        private string _sex;
        private string _birthDate;
        public PersonelViewModel()
        {
            SBirthDate = string.Empty;
            Sex = string.Empty;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Sex { get { return IsMale.Value ? "Erkek" : "Kadın"; } set { _sex = value; } }
        public Nullable<bool> IsMale { get; set; }
        public string SBirthDate { get { return BirthDate.ToShortDateString(); } set { _birthDate = value; } }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class PersonelListResponseModel : BaseResponseModel
    {
        public PersonelListResponseModel()
        {
            Data = new List<PersonelViewModel>();
            Message = string.Empty;
        }
        public List<PersonelViewModel> Data { get; set; }
    }

    public class PersonelResponseModel : BaseResponseModel
    {
        public PersonelResponseModel()
        {
            Data = new PersonelViewModel();
            Message = string.Empty;
        }
        public PersonelViewModel Data { get; set; }

    }

    public class BaseResponseModel
    {
        public string Message { get; set; }
        public int Code { get; set; }
    }
}
