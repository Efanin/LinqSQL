﻿namespace WinFormsApp19
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Activation = ItemActivation.OneClick;
            listView1.Alignment = ListViewAlignment.Default;
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.LabelWrap = false;
            listView1.Location = new Point(80, 12);
            listView1.Name = "listView1";
            listView1.Size = new Size(563, 426);
            listView1.TabIndex = 0;
            listView1.TileSize = new Size(600, 50);
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Tile;
            // 
            // columnHeader1
            // 
            columnHeader1.Width = 600;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listView1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView listView1;
        private ColumnHeader columnHeader1;
    }
}
