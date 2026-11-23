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
            buttonCancel = new Button();
            textBox1 = new TextBox();
            places = new TreeBox(components);
            sbCurrency = new SmartLib.Base.SmartBox.SmartBox(components);
            ((System.ComponentModel.ISupportInitialize)places).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sbCurrency).BeginInit();
            SuspendLayout();
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.AutoSize = true;
            buttonCancel.Location = new Point(361, 190);
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
            textBox1.Size = new Size(364, 23);
            textBox1.TabIndex = 25;
            // 
            // places
            // 
            places.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            places.Location = new Point(73, 41);
            places.Name = "places";
            places.Placeholder = "Укажите склад";
            places.Size = new Size(364, 23);
            places.TabIndex = 33;
            places.Value = "";
            // 
            // sbCurrency
            // 
            sbCurrency.Location = new Point(73, 85);
            sbCurrency.Name = "sbCurrency";
            sbCurrency.Size = new Size(93, 23);
            sbCurrency.TabIndex = 34;
            sbCurrency.Value = "";
            // 
            // TestLookup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(449, 227);
            Controls.Add(sbCurrency);
            Controls.Add(places);
            Controls.Add(textBox1);
            Controls.Add(buttonCancel);
            Name = "TestLookup";
            Text = "TestLoolkup";
            Load += TestLookup_Load;
            ((System.ComponentModel.ISupportInitialize)places).EndInit();
            ((System.ComponentModel.ISupportInitialize)sbCurrency).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonCancel;
        private TextBox textBox1;
        private TreeBox places;
        private SmartLib.Base.SmartBox.SmartBox sbCurrency;
    }
}