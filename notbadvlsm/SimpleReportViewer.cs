using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;
namespace Notepad
{
    public class SimpleReportViewer : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleReportViewer"/> class.
        /// </summary>
        //You can remove this constructor if you don't want to use the IDE forms designer to tweak its layout.
        public SimpleReportViewer()
        {
            InitializeComponent();
            if (!DesignMode) throw new InvalidOperationException("Default constructor is for designer use only. Use static methods instead.");
        }

        private SimpleReportViewer(string reportText)
        {
            InitializeComponent();
            txtReportContents.Text = reportText;
        }
        private SimpleReportViewer(string reportText, Size s)
        {
            InitializeComponent();
            
            txtReportContents.Text = reportText;
            this.Size = s;
            txtReportContents.Size = s;

        }

        private SimpleReportViewer(string reportText, string reportTitle)
        {
            InitializeComponent();
            txtReportContents.Text = reportText;
            Text = "Report Viewer:";
        }

        /// <summary>
        /// Shows a SimpleReportViewer with the specified text and title.
        /// </summary>
        /// <param name="reportText">The report text.</param>
        /// <param name="reportTitle">The report title.</param>
        public static void Show(string reportText, string reportTitle)
        {
            new SimpleReportViewer(reportText, reportTitle).Show();
        }

        /// <summary>
        /// Shows a SimpleReportViewer with the specified text, title, and parent form.
        /// </summary>
        /// <param name="reportText">The report text.</param>
        /// <param name="reportTitle">The report title.</param>
        /// <param name="owner">The owner.</param>
        public static void Show(string reportText, string reportTitle, Form owner)
        {
            new SimpleReportViewer(reportText, reportTitle).Show(owner);
        }
        public static void Show(string reportText, Size s)
        {
            new SimpleReportViewer(reportText, s);
        }

        /// <summary>
        /// Shows a SimpleReportViewer with the specified text, title, and parent form as a modal dialog that prevents focus transfer.
        /// </summary>
        /// <param name="reportText">The report text.</param>
        /// <param name="reportTitle">The report title.</param>
        /// <param name="owner">The owner.</param>
        public static void ShowDialog(string reportText, string reportTitle, Form owner)
        {
            new SimpleReportViewer(reportText, reportTitle).ShowDialog(owner);
        }

        /// <summary>
        /// Shows a SimpleReportViewer with the specified text and the default window title.
        /// </summary>
        /// <param name="reportText">The report text.</param>
        public static void Show(string reportText)
        {
            new SimpleReportViewer(reportText).Show();
        }

        /// <summary>
        /// Shows a SimpleReportViewer with the specified text, the default window title, and the specified parent form.
        /// </summary>
        /// <param name="reportText">The report text.</param>
        /// <param name="owner">The owner.</param>
        public static void Show(string reportText, Form owner)
        {
            new SimpleReportViewer(reportText).Show(owner);
        }

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtReportContents = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtReportContents
            // 
            this.txtReportContents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtReportContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReportContents.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReportContents.Location = new System.Drawing.Point(0, 0);
            this.txtReportContents.Multiline = true;
            this.txtReportContents.Name = "txtReportContents";
            this.txtReportContents.ReadOnly = true;
            this.txtReportContents.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtReportContents.Size = new System.Drawing.Size(484, 311);
            this.txtReportContents.TabIndex = 0;
            this.txtReportContents.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReportContents_KeyDown);
            // 
            // SimpleReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 311);
            this.Controls.Add(this.txtReportContents);
            this.Name = "SimpleReportViewer";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Report Viewer";
            this.Load += new System.EventHandler(this.SimpleReportViewer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SimpleReportViewer_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtReportContents;

        private void SimpleReportViewer_Load(object sender, EventArgs e)
        {

        }

        private void SimpleReportViewer_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.Close();
            }
            
        }

        private void txtReportContents_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Close();
            }
        }
    }
}
