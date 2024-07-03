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
        public int EditIndex;

        public dlgCreateOrEditPerson(Person p = null, int editIndex = 0)
        {
            InitializeComponent();

            if (p != null)
            {
                this.Text = "Modifica contatto";
                LoadPerson(p);
            }

            EditIndex = editIndex;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsFormValid())
                return;

            Person p = new Person();
            p.Name = txtName.Text;
            p.Surname = txtSurname.Text;
            p.Address = txtAddress.Text;
            p.PhoneNumber = txtPhone.Text;
            p.Age = (int)txtAge.Value;

            Person = p;
            Close();
        }

        void LoadPerson(Person p)
        {
            txtName.Text = p.Name;
            txtSurname.Text = p.Surname;
            txtAddress.Text = p.Address;
            txtPhone.Text = p.PhoneNumber;
            txtAge.Value = p.Age;
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
