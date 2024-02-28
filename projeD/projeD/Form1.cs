using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static projeD.Form1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace projeD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class dugum
        {
            public int kod;
            public int fiyat;
            public string isim;
            public dugum sonraki;
            public dugum onceki;
        }

        dugum ilk = null;
        dugum son = null;

        private void eb1_Click(object sender, EventArgs e)
        {
            if (etb1.Text == "" || etb2.Text == "" || etb3.Text == "")
            {
                MessageBox.Show("Ürün bilgilerini giriniz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dugum yeni = new dugum();
                yeni.kod = Convert.ToInt32(etb1.Text);
                yeni.isim = etb2.Text;
                yeni.fiyat = Convert.ToInt32(etb3.Text);
                if (ilk == null) 
                {
                    ilk = yeni;
                    son = yeni;
                }
                else
                {
                    dugum isaretci1 = null;
                    dugum isaretci2 = ilk;
                    while (isaretci2 != null)
                    {
                        if (yeni.kod == isaretci2.kod)
                        {
                            MessageBox.Show("Ürün mevcut", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                        else  //eklemeler
                        {
                            if (yeni.kod < isaretci2.kod && isaretci2 == ilk)  
                            {
                                ilk.onceki = yeni;
                                yeni.sonraki = ilk;
                                ilk = yeni;
                                ilk.onceki = null;
                                break;
                            }
                            if (yeni.kod < isaretci2.kod)  
                            {
                                isaretci1.sonraki = yeni;
                                yeni.onceki = isaretci1;
                                isaretci2.onceki = yeni;
                                yeni.sonraki = isaretci2;
                                break;
                            }
                            if (yeni.kod > isaretci2.kod && isaretci2 == son)  
                            {
                                son.sonraki = yeni;
                                yeni.onceki = son;
                                son = yeni;
                                son.sonraki = null;
                                break;
                            }
                        }

                        isaretci1 = isaretci2;
                        isaretci2 = isaretci2.sonraki;
                    }
                }
            }
        }

        private void sb1_Click(object sender, EventArgs e)
        {
            if (stb1.Text == "")
            {
                MessageBox.Show("Ürün kodu boş bırakılamaz", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (ilk == null)
                {
                    MessageBox.Show("Silinecek Kayıt Yok", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    dugum isaretci1 = null; // düğümleri bul
                    dugum isaretci2 = ilk;
                    dugum isaretci3 = ilk.sonraki;  
                    int urunSil = Convert.ToInt32(stb1.Text);
                    while (isaretci2 != null) //silme
                    {

                        if (urunSil == isaretci2.kod && ilk == son)  
                        {
                            ilk = null;
                            son = null;
                            break;
                        }
                        if (urunSil == isaretci2.kod && isaretci2 == ilk)  
                        {
                            ilk = ilk.sonraki;
                            ilk.onceki = null;
                            break;
                        }
                        if (urunSil == isaretci2.kod && isaretci2 == son)  
                        {
                            son = son.onceki;
                            son.sonraki = null;
                            break;
                        }
                        if (urunSil == isaretci2.kod && isaretci2 != ilk && isaretci2 != son)  
                        {
                            isaretci1.sonraki = isaretci3;
                            isaretci3.onceki = isaretci1;
                            break;
                        }
                        if (urunSil > isaretci2.kod && isaretci3 == null)
                        {
                            MessageBox.Show("Silinecek Kayıt Yok", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                        if (urunSil < isaretci2.kod && isaretci3 == null)
                        {
                            MessageBox.Show("Silinecek Kayıt Yok", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }

                        isaretci1 = isaretci2;
                        isaretci2 = isaretci2.sonraki;
                        isaretci3 = isaretci3.sonraki;
                    }
                }


            }
        }

        private void sb2_Click(object sender, EventArgs e)
        {
            if (stb1.Text == "")
            {
                MessageBox.Show("Ürün kodu giriniz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int kodBul = Convert.ToInt32(stb1.Text);
                Boolean durum = true;
                dugum isaretci = ilk;
                while (isaretci != null)
                {
                    if (isaretci.kod == kodBul)
                    {
                        stb2.Text = isaretci.isim;
                        stb3.Text = Convert.ToString(isaretci.fiyat);
                        durum = false;
                    }
                    isaretci = isaretci.sonraki;
                }
                if (durum)
                {
                    stb1.Text = "";
                    stb2.Text = "";
                    stb3.Text = "";
                    MessageBox.Show("Kayıt Bulunamadı", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void gb1_Click(object sender, EventArgs e)
        {
            if (gtb1.Text == "" || gtb2.Text == "" || gtb3.Text == "")
            {
                MessageBox.Show("Ürün bilgilerini giriniz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dugum yeni = new dugum();
                yeni.kod = Convert.ToInt32(gtb1.Text);
                yeni.isim = gtb2.Text;
                yeni.fiyat = Convert.ToInt32(gtb3.Text);
                Boolean durum = true;
                dugum isaretci = ilk;
                while (isaretci != null)
                {
                    if (yeni.kod == isaretci.kod)
                    {
                        isaretci.isim = yeni.isim;
                        isaretci.fiyat = yeni.fiyat;
                        durum = false;
                    }
                    isaretci = isaretci.sonraki;
                }
                if (durum)
                {
                    gtb1.Text = "";
                    gtb2.Text = "";
                    gtb3.Text = "";
                    MessageBox.Show("Kayıt Bulunamadı", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }
      
        private void ulist_Click_1(object sender, EventArgs e)
        {
            dugum isaretci = ilk;  //satır ekleme
            dgw1.Rows.Clear();
            if (ilk != son) 
            {
                int satirSayisi = 0;
                while (isaretci.sonraki != null)
                {
                    satirSayisi++;
                    isaretci = isaretci.sonraki;
                }
                dgw1.Rows.Add(satirSayisi);
            }

            int i = 0;
            int j = 0;
            isaretci = ilk;
            while (isaretci != null)
            {
                dgw1.Rows[i].Cells[j].Value = isaretci.kod;
                dgw1.Rows[i].Cells[j + 1].Value = isaretci.isim;
                dgw1.Rows[i].Cells[j + 2].Value = isaretci.fiyat;
                isaretci = isaretci.sonraki;
                i++;
            }
        }

        private void gb2_Click_1(object sender, EventArgs e)
        {
            if (gtb1.Text == "")
            {
                MessageBox.Show("Ürün kodu giriniz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int kodBul = Convert.ToInt32(gtb1.Text);
                Boolean durum = true;
                dugum isaretci = ilk;
                while (isaretci != null)
                {
                    if (isaretci.kod == kodBul)
                    {
                        gtb2.Text = isaretci.isim;
                        gtb3.Text = Convert.ToString(isaretci.fiyat);
                        durum = false;
                    }
                    isaretci = isaretci.sonraki;
                }
                if (durum)
                {
                    gtb1.Text = "";
                    gtb2.Text = "";
                    gtb3.Text = "";
                    MessageBox.Show("Kayıt Bulunamadı", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void dgw1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilenAlan = dgw1.SelectedCells[0].RowIndex;
            stb1.Text = dgw1.Rows[secilenAlan].Cells[0].Value.ToString();
            stb2.Text = dgw1.Rows[secilenAlan].Cells[1].Value.ToString();
            stb3.Text = dgw1.Rows[secilenAlan].Cells[2].Value.ToString();

            gtb1.Text = dgw1.Rows[secilenAlan].Cells[0].Value.ToString();
            gtb2.Text = dgw1.Rows[secilenAlan].Cells[1].Value.ToString();
            gtb3.Text = dgw1.Rows[secilenAlan].Cells[2].Value.ToString();
        }

        private void stb2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
