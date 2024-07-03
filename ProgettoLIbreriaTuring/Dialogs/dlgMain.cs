using ProgettoLIbreriaTuring.DBs;
using ProgettoLIbreriaTuring.Dialogs;
using ProgettoLIbreriaTuring.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProgettoLIbreriaTuring
{
    public partial class dlgMain : Form
    {
        IPeopleDB DB;
        PersonCollection people;
        User loggedUser;

        public dlgMain(User _loggedUser)
        {
            InitializeComponent();

            cmbDbType.SelectedIndex = 0;
            LoadPeopleOnGridView();

            loggedUser = _loggedUser;
        }

        void LoadPeopleOnGridView()
        {
            people = DB.Load();
            UpdateGridView();
        }

        private void UpdateGridView()
        {
            BindingSource source = new BindingSource();
            source.DataSource = people;
            dgrPeople.DataSource = source;
        }

        Person CreatePersonFromDialog()
        {
            dlgCreateOrEditPerson dlg = new dlgCreateOrEditPerson();
            dlg.ShowDialog();

            return dlg.Person;
        }

        Person EditPersonFromDialog(Person p)
        {
            dlgCreateOrEditPerson dlg = new dlgCreateOrEditPerson(p);
            dlg.ShowDialog();

            return dlg.Person;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            Person createdPerson = CreatePersonFromDialog();

            if (createdPerson != null)
            {
                people.Add(createdPerson);
                DB.Add(createdPerson);

                UpdateGridView();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var selectedRow = dgrPeople.SelectedRows;

            if (selectedRow.Count == 0)
                return;

            if (selectedRow[0].DataBoundItem is Person p)
            {
                int index = selectedRow[0].Index;
                Person personEdited = EditPersonFromDialog(p);

                if (personEdited != null)
                {
                    people.RemoveAt(index);
                    people.Insert(index, personEdited);
                    UpdateGridView();

                    DB.Update(index, personEdited);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selectedRow = dgrPeople.SelectedRows;

            if (selectedRow.Count == 0)
                return;

            if (selectedRow[0].DataBoundItem is Person p)
            {
                people.Remove(p);
                UpdateGridView();

                DB.Delete(p);
            }
        }

        private void cmbDbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbDbType.SelectedIndex)
            {
                case 0:
                    {
                        DB = new CsvDB();
                        break;
                    }
                case 1:
                    {
                        DB = new FolderDB();
                        break;
                    }
                case 2:
                    {
                        DB = new MySqlDB();
                        break;
                    }
            }

            LoadPeopleOnGridView();
        }
    }
}
