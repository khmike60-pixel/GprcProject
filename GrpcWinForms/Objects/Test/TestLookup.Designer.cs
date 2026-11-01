using GrpcCommonNet.Library.Common;
using GrpcWinForms.Controls.TreeBox;

namespace GrpcWinForms.Objects.Test
{
    partial class TestLookup
    {
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
            components = new System.ComponentModel.Container();
            C1.Win.TreeView.C1TreeColumn c1TreeColumn1 = new C1.Win.TreeView.C1TreeColumn();
            buttonCancel = new Button();
            textBox1 = new TextBox();
            places = new TreeBox(components);
            c1TreeView1 = new C1.Win.TreeView.C1TreeView();
            ((System.ComponentModel.ISupportInitialize)places).BeginInit();
            ((System.ComponentModel.ISupportInitialize)c1TreeView1).BeginInit();
            SuspendLayout();
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.AutoSize = true;
            buttonCancel.Location = new Point(327, 190);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 25);
            buttonCancel.TabIndex = 23;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(73, 12);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Произвольный  текст";
            textBox1.Size = new Size(330, 23);
            textBox1.TabIndex = 25;
            // 
            // places
            // 
            places.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            places.Location = new Point(73, 41);
            places.Name = "places";
            places.Placeholder = "Yjdsq";
            places.Size = new Size(330, 23);
            places.TabIndex = 33;
            places.Value = "";
            // 
            // c1TreeView1
            // 
            // 
            // 
            // 
            c1TreeView1.ButtonImageList.ColorDepth = ColorDepth.Depth32Bit;
            c1TreeView1.ButtonImageList.ImageSize = new Size(9, 9);
            c1TreeView1.ButtonImageList.TransparentColor = Color.Transparent;
            // 
            // 
            // 
            c1TreeView1.CheckImageList.ColorDepth = ColorDepth.Depth32Bit;
            c1TreeView1.CheckImageList.ImageSize = new Size(13, 13);
            c1TreeView1.CheckImageList.TransparentColor = Color.Transparent;
            c1TreeColumn1.HeaderText = "Column1";
            c1TreeColumn1.Name = "Column1";
            c1TreeView1.Columns.Add(c1TreeColumn1);
            c1TreeView1.Location = new Point(111, 85);
            c1TreeView1.Name = "c1TreeView1";
            c1TreeView1.Size = new Size(200, 91);
            c1TreeView1.TabIndex = 34;
            // 
            // TestLookup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(415, 227);
            Controls.Add(c1TreeView1);
            Controls.Add(places);
            Controls.Add(textBox1);
            Controls.Add(buttonCancel);
            Name = "TestLookup";
            Text = "TestLoolkup";
            Load += TestLookup_Load;
            ((System.ComponentModel.ISupportInitialize)places).EndInit();
            ((System.ComponentModel.ISupportInitialize)c1TreeView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonCancel;
        private TextBox textBox1;
        private TreeBox places;
        private C1.Win.TreeView.C1TreeView c1TreeView1;
    }
}