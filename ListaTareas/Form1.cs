using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using System.Collections;

namespace ListaTareas
{
    public partial class ToDoList : Form
    {
        private const int V = 0;
        private object todoList;


        public ToDoList()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //CAJA DE DESCRIPCIÓN
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ELIMINAR TAREA
            // Verificar si hay una fila seleccionada
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Eliminar la fila seleccionada del DataGridView
                dataGridView1.Rows.Remove(selectedRow);

                // Limpiar los TextBox después de eliminar la actividad
                textBox1.Clear();
                titleTexbox.Clear();
                descriptionTexbox.Clear();
            }
        }

        private void ToDoList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // CAJA DE LA LISTA DE LAS TAREAS PENDIENTES
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            // SUBIR NUEVA TAREA PENDIENTE
            // Limpiar los TextBox para permitir la entrada de nuevos datos
            textBox1.Clear();
            titleTexbox.Clear();
            descriptionTexbox.Clear();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //GUARDAR TAREA
            // Verificar si hay una celda seleccionada
            if (dataGridView1.SelectedCells.Count > 0)
            {
                // Obtener la celda seleccionada
                DataGridViewCell cell = dataGridView1.SelectedCells[0];

                // Actualizar los valores de la celda con los TextBox correspondientes
                cell.OwningRow.Cells[0].Value = textBox1.Text; // Hora
                cell.OwningRow.Cells[1].Value = titleTexbox.Text; // Actividad
                cell.OwningRow.Cells[2].Value = descriptionTexbox.Text; // Descripción

                // Limpiar los TextBox después de guardar
                textBox1.Clear();
                titleTexbox.Clear();
                descriptionTexbox.Clear();
            }
            {
                // Obtener los datos ingresados en los TextBox
                string hora = textBox1.Text;
                string actividad = titleTexbox.Text;
                string descripcion = descriptionTexbox.Text;

                // Agregar una nueva fila al DataGridView con los datos ingresados
                dataGridView1.Rows.Add(hora, actividad, descripcion);

                // Limpiar los TextBox después de guardar los datos
                textBox1.Clear();
                titleTexbox.Clear();
                descriptionTexbox.Clear();
            }
        }
        private void edithButton_Click(object sender, EventArgs e)
        {
            // EDITAR TAREA
            // Verificar si hay una celda seleccionada
            if (dataGridView1.SelectedCells.Count > 0)
            {
                // Obtener la celda seleccionada
                DataGridViewCell cell = dataGridView1.SelectedCells[0];

                // Mostrar la información de la celda en los TextBox correspondientes
                textBox1.Text = cell.OwningRow.Cells[0].Value.ToString(); // Hora
                titleTexbox.Text = cell.OwningRow.Cells[1].Value.ToString(); // Actividad
                descriptionTexbox.Text = cell.OwningRow.Cells[2].Value.ToString(); // Descripción
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void titleTexbox_TextChanged(object sender, EventArgs e)
        {
            // CAJA DE TITULO DE LA TAREA

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            // CALENDARIO
            CargarFecha();
        }

        private void ToDoList_Load(object sender, EventArgs e)
        {
            // creamos columnas


            for (int f = 1; f <= 100; f++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.DataSource = todoList;
            }
            CargarFecha();
        }

        private void CargarFecha()
        {
            DateTime select = monthCalendar1.SelectionStart;
            label13.Text = "Fecha seleccionada:" + select.ToString("dd/MM/yyyy");
            string fecha = select.Year.ToString() + "-" + select.Month.ToString("00") + "-" + select.Day.ToString("00");
            if (!File.Exists(fecha))
            {
                StreamWriter archivo = new StreamWriter(fecha);
                DateTime fe = DateTime.Today;
                for (int f = 1; f <= 100; f++)
                {
                    archivo.WriteLine(fe.ToString("HH:mm"));
                    archivo.WriteLine("");
                    fe = fe.AddMinutes(15);
                }
                archivo.Close();
            }
            StreamReader archivo2 = new StreamReader(fecha);
            int x = 0;
            while (!archivo2.EndOfStream)

            {
                string linea1 = archivo2.ReadLine();
                string linea2 = archivo2.ReadLine();
                dataGridView1.Rows[x].Cells[0].Value = linea1;
                dataGridView1.Rows[x].Cells[1].Value = linea2;
                x++;
            }
            archivo2.Close();
        }



        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = selectedRow.Cells[0].Value.ToString();
                titleTexbox.Text = selectedRow.Cells[0].Value.ToString();
                descriptionTexbox.Text = selectedRow.Cells[1].Value.ToString();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnTareaRealizada_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[rowIndex].DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Strikeout);
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

    






