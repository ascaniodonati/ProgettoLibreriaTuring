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

        public dlgMain()
        {
            InitializeComponent();

            DB = new CsvDB();
            LoadPeopleOnGridView();
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

        Person EditPersonFromDialog(int index, Person p)
        {
            dlgCreateOrEditPerson dlg = new dlgCreateOrEditPerson(p, index);
            dlg.ShowDialog();

            return dlg.Person;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            Person createdPerson = CreatePersonFromDialog();

            if (createdPerson != null)
            {
                people.Add(createdPerson);
                DB.Save(people);

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
                Person personEdited = EditPersonFromDialog(index, p);

                if (personEdited != null)
                {
                    people.RemoveAt(index);
                    people.Insert(index, personEdited);
                    UpdateGridView();

                    DB.Save(people);
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

                DB.Save(people);
            }
        }

        private void btnChangeDB_Click(object sender, EventArgs e)
        {
            if (DB.GetType() == typeof(CsvDB))
            {
                DB = new MySqlDB();
                LoadPeopleOnGridView();

                btnChangeDB.Text = "Passa al database CSV";
            }
            else if (DB.GetType() == typeof(MySqlDB))
            {
                DB = new CsvDB();
                LoadPeopleOnGridView();

                btnChangeDB.Text = "Passa al database MySQL";
            }
        }
    }
}
