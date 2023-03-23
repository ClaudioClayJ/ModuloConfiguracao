namespace WindowsFormsAppPrincipal
{
    partial class FormCadastroGrupoUsuario
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label nomeGrupoLabel;
            this.nomeGrupoTextBox = new System.Windows.Forms.TextBox();
            this.grupoUsuarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSalvarCadastroGrupoUsuario = new System.Windows.Forms.Button();
            this.buttonCancelarCadastroGrupoUsuario = new System.Windows.Forms.Button();
            nomeGrupoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grupoUsuarioBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // nomeGrupoLabel
            // 
            nomeGrupoLabel.AutoSize = true;
            nomeGrupoLabel.Location = new System.Drawing.Point(291, 146);
            nomeGrupoLabel.Name = "nomeGrupoLabel";
            nomeGrupoLabel.Size = new System.Drawing.Size(87, 16);
            nomeGrupoLabel.TabIndex = 1;
            nomeGrupoLabel.Text = "Nome Grupo:";
            // 
            // nomeGrupoTextBox
            // 
            this.nomeGrupoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.grupoUsuarioBindingSource, "NomeGrupo", true));
            this.nomeGrupoTextBox.Location = new System.Drawing.Point(133, 183);
            this.nomeGrupoTextBox.Name = "nomeGrupoTextBox";
            this.nomeGrupoTextBox.Size = new System.Drawing.Size(399, 22);
            this.nomeGrupoTextBox.TabIndex = 2;
            // 
            // grupoUsuarioBindingSource
            // 
            this.grupoUsuarioBindingSource.DataSource = typeof(Models.GrupoUsuario);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(475, 46);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cadastro Grupo Usuario";
            // 
            // buttonSalvarCadastroGrupoUsuario
            // 
            this.buttonSalvarCadastroGrupoUsuario.Location = new System.Drawing.Point(263, 385);
            this.buttonSalvarCadastroGrupoUsuario.Name = "buttonSalvarCadastroGrupoUsuario";
            this.buttonSalvarCadastroGrupoUsuario.Size = new System.Drawing.Size(76, 32);
            this.buttonSalvarCadastroGrupoUsuario.TabIndex = 4;
            this.buttonSalvarCadastroGrupoUsuario.Text = "Salvar";
            this.buttonSalvarCadastroGrupoUsuario.UseVisualStyleBackColor = true;
            this.buttonSalvarCadastroGrupoUsuario.Click += new System.EventHandler(this.buttonSalvarCadastroGrupoUsuario_Click);
            // 
            // buttonCancelarCadastroGrupoUsuario
            // 
            this.buttonCancelarCadastroGrupoUsuario.Location = new System.Drawing.Point(397, 385);
            this.buttonCancelarCadastroGrupoUsuario.Name = "buttonCancelarCadastroGrupoUsuario";
            this.buttonCancelarCadastroGrupoUsuario.Size = new System.Drawing.Size(90, 32);
            this.buttonCancelarCadastroGrupoUsuario.TabIndex = 5;
            this.buttonCancelarCadastroGrupoUsuario.Text = "Cancelar";
            this.buttonCancelarCadastroGrupoUsuario.UseVisualStyleBackColor = true;
            this.buttonCancelarCadastroGrupoUsuario.Click += new System.EventHandler(this.buttonCancelarCadastroGrupoUsuario_Click);
            // 
            // FormCadastroGrupoUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonCancelarCadastroGrupoUsuario);
            this.Controls.Add(this.buttonSalvarCadastroGrupoUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(nomeGrupoLabel);
            this.Controls.Add(this.nomeGrupoTextBox);
            this.Name = "FormCadastroGrupoUsuario";
            this.Text = "FormCadastroGrupoUsuario";
            this.Load += new System.EventHandler(this.FormCadastroGrupoUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grupoUsuarioBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource grupoUsuarioBindingSource;
        private System.Windows.Forms.TextBox nomeGrupoTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSalvarCadastroGrupoUsuario;
        private System.Windows.Forms.Button buttonCancelarCadastroGrupoUsuario;
    }
}