
namespace Automata
{
    partial class MainInterface
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.labelNumberOfOutputs = new System.Windows.Forms.Label();
            this.numericOutputs = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxStates = new System.Windows.Forms.TextBox();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericOutputs)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.buttonConfirm);
            this.mainPanel.Controls.Add(this.textBoxStates);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.numericOutputs);
            this.mainPanel.Controls.Add(this.labelNumberOfOutputs);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 450);
            this.mainPanel.TabIndex = 0;
            // 
            // labelNumberOfOutputs
            // 
            this.labelNumberOfOutputs.AutoSize = true;
            this.labelNumberOfOutputs.Location = new System.Drawing.Point(19, 22);
            this.labelNumberOfOutputs.Name = "labelNumberOfOutputs";
            this.labelNumberOfOutputs.Size = new System.Drawing.Size(237, 17);
            this.labelNumberOfOutputs.TabIndex = 0;
            this.labelNumberOfOutputs.Text = "Cuantos outputs va a tener la tabla?";
            // 
            // numericOutputs
            // 
            this.numericOutputs.Location = new System.Drawing.Point(262, 22);
            this.numericOutputs.Name = "numericOutputs";
            this.numericOutputs.Size = new System.Drawing.Size(73, 22);
            this.numericOutputs.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Inserte cada estado con sus respectivas salidas:";
            // 
            // textBoxStates
            // 
            this.textBoxStates.Location = new System.Drawing.Point(25, 125);
            this.textBoxStates.Name = "textBoxStates";
            this.textBoxStates.Size = new System.Drawing.Size(33, 22);
            this.textBoxStates.TabIndex = 3;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(341, 19);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(88, 23);
            this.buttonConfirm.TabIndex = 4;
            this.buttonConfirm.Text = "Confirmar";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // MainInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainPanel);
            this.Name = "MainInterface";
            this.Text = "Form1";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericOutputs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.NumericUpDown numericOutputs;
        private System.Windows.Forms.Label labelNumberOfOutputs;
        private System.Windows.Forms.TextBox textBoxStates;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonConfirm;
    }
}

