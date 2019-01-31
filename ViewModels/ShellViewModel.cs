using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFUI.Models;
using WPFUI.Persistance;

namespace WPFUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        private string firstName;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        private string lastName;
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
            
        }

        private BindableCollection<PersonModel> people = new BindableCollection<PersonModel>();

        public BindableCollection<PersonModel> People
        {
            get { return people; }
            set { people = value; }
        }

        private PersonModel selectedPerson;

        public PersonModel SelectedPerson
        {
            get
            {
                return selectedPerson;
            }
            set
            {
                selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson);
            }
        }

        //ctors 
        public ShellViewModel()
        {
            People.Add(new PersonModel(FirstName = "Steven", LastName = "Gerrard"));
            People.Add(new PersonModel( FirstName = "Xabi", LastName = "Alonso" ));
            People.Add(new PersonModel (FirstName = "Jaime", LastName = "Carragher" ));
        }

        //methods

        /// <summary>
        /// If we return false the button is disabled
        /// </summary>
        /// <returns></returns>
        public bool CanClearText(string firstName, string lastName)
        {
            return !String.IsNullOrWhiteSpace(firstName) || !String.IsNullOrWhiteSpace(lastName);
        }

        public void ClearText(string firstName, string lastName)
        {
            FirstName = "";
            LastName = "";
        }

        public void LoadPageOne()
        {
            ActivateItem(new FirstChildViewModel());
        }

        public void LoadPageTwo()
        {
            ActivateItem(new SecondChildViewModel());
        }

        public bool CanAddPerson(string firstName, string lastName)
        {
            return !String.IsNullOrWhiteSpace(firstName) && !String.IsNullOrWhiteSpace(lastName);
        }

        public void AddPerson(string firstName, string lastName)
        {


            PersonModel person = new PersonModel(this.FirstName, this.LastName);


            _context.PersonModels.Add(person);
            _context.SaveChanges();

            
        }
    }
}
