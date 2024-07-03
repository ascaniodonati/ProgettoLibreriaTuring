namespace ProgettoLIbreriaTuring
{
    partial class dlgMain
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgrPeople = new System.Windows.Forms.DataGridView();
            this.btnChangeDB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgrPeople)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(648, 445);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(147, 35);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "Crea";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(495, 445);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(147, 35);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Modifica";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(342, 445);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(147, 35);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Elimina";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgrPeople
            // 
            this.dgrPeople.AllowUserToAddRows = false;
            this.dgrPeople.AllowUserToDeleteRows = false;
            this.dgrPeople.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrPeople.Location = new System.Drawing.Point(13, 13);
            this.dgrPeople.MultiSelect = false;
            this.dgrPeople.Name = "dgrPeople";
            this.dgrPeople.RowHeadersWidth = 51;
            this.dgrPeople.RowTemplate.Height = 24;
            this.dgrPeople.Size = new System.Drawing.Size(782, 412);
            this.dgrPeople.TabIndex = 3;
            // 
            // btnChangeDB
            // 
            this.btnChangeDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChangeDB.Location = new System.Drawing.Point(12, 445);
            this.btnChangeDB.Name = "btnChangeDB";
            this.btnChangeDB.Size = new System.Drawing.Size(200, 35);
            this.btnChangeDB.TabIndex = 4;
            this.btnChangeDB.Text = "Passa al database MySQL";
            this.btnChangeDB.UseVisualStyleBackColor = true;
            this.btnChangeDB.Click += new System.EventHandler(this.btnChangeDB_Click);
            // 
            // dlgMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 492);
            this.Controls.Add(this.btnChangeDB);
            this.Controls.Add(this.dgrPeople);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnNew);
            this.Name = "dlgMain";
            this.Text = "Rubrica";
            ((System.ComponentModel.ISupportInitialize)(this.dgrPeople)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgrPeople;
        private System.Windows.Forms.Button btnChangeDB;
    }
}

