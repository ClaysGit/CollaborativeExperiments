namespace OAuthManager
{
    partial class OAuthTokenManagerForm
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
            this.RequestConsent = new System.Windows.Forms.Button();
            this.WebBrowser = new System.Windows.Forms.WebBrowser();
            this.Submit = new System.Windows.Forms.Button();
            this.CodeTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // RequestConsent
            // 
            this.RequestConsent.Location = new System.Drawing.Point(12, 12);
            this.RequestConsent.Name = "RequestConsent";
            this.RequestConsent.Size = new System.Drawing.Size(295, 49);
            this.RequestConsent.TabIndex = 0;
            this.RequestConsent.Text = "Request Consent";
            this.RequestConsent.UseVisualStyleBackColor = true;
            this.RequestConsent.Click += new System.EventHandler(this.RequestConsent_Click);
            // 
            // WebBrowser
            // 
            this.WebBrowser.Location = new System.Drawing.Point(12, 67);
            this.WebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.WebBrowser.Name = "WebBrowser";
            this.WebBrowser.Size = new System.Drawing.Size(755, 509);
            this.WebBrowser.TabIndex = 3;
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(463, 38);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(295, 23);
            this.Submit.TabIndex = 2;
            this.Submit.Text = "Submit OAuth 2.0 Token";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // CodeTextbox
            // 
            this.CodeTextbox.Location = new System.Drawing.Point(463, 12);
            this.CodeTextbox.Name = "CodeTextbox";
            this.CodeTextbox.Size = new System.Drawing.Size(295, 20);
            this.CodeTextbox.TabIndex = 1;
            // 
            // OAuthTokenManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 588);
            this.Controls.Add(this.WebBrowser);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.CodeTextbox);
            this.Controls.Add(this.RequestConsent);
            this.Name = "OAuthTokenManagerForm";
            this.Text = "OAuth 2.0 Token Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RequestConsent;
        private System.Windows.Forms.WebBrowser WebBrowser;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.TextBox CodeTextbox;
    }
}

