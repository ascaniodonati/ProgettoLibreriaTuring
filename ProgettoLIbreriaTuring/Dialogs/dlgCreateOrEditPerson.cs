using ProgettoLIbreriaTuring.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProgettoLIbreriaTuring.Dialogs
{
    public partial class dlgCreateOrEditPerson : Form
    {
        public Person Person;

        public dlgCreateOrEditPerson(Person p = null)
        {
            InitializeComponent();

            if (p != null)
            {
                this.Text = "Modifica contatto";
                Person = p;
                LoadPerson();
            }
            else
                Person = new Person();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsFormValid())
                return;

            Person.Name = txtName.Text;
            Person.Surname = txtSurname.Text;
            Person.Address = txtAddress.Text;
            Person.PhoneNumber = txtPhone.Text;
            Person.Age = (int)txtAge.Value;

            Close();
        }

        void LoadPerson()
        {
            txtName.Text = Person.Name;
            txtSurname.Text = Person.Surname;
            txtAddress.Text = Person.Address;
            txtPhone.Text = Person.PhoneNumber;
            txtAge.Value = Person.Age;
        }

        private bool IsFormValid()
        {
            if (txtName.Text == string.Empty)
            {
                MessageBox.Show("Il campo Nome non può essere vuoto");
                return false;
            }
            else if (txtSurname.Text == string.Empty)
            {
                MessageBox.Show("Il campo Cognome non può essere vuoto");
                return false;
            }
            else if (txtAddress.Text == string.Empty)
            {
                MessageBox.Show("Il campo Indirizzo non può essere vuoto");
                return false;
            }
            else if (txtPhone.Text == string.Empty)
            {
                MessageBox.Show("Il campo Telefono non può essere vuoto");
                return false;
            }

            return true;
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            Person = null;
            Close();
        }
    }
}
