using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace CoCaro
{
    public class ChessBoardsetup 
    {
        #region Properties
        private Panel banco;
        private List<Player> player;
        public List<Player> Player { get => player; set => player = value; }
        private int currentPlayer;
        public int CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }
        private List<List<Button>> matrix;

        //tao mang ma tran 
        public List<List<Button>> Matrix { get => matrix; set => matrix = value; }

        private TextBox nuocdi; 
        public TextBox  Nuocdi { get => nuocdi; set => nuocdi = value; }
        private SqlConnection conn;
        private SqlCommand commd;
        private string sqlstr;
        private int lanchoi;
        private int ChieuNgangBC = cons.board_width;
        private int ChieuCaoBC = cons.board_height;
        private int sonuoc = 0;
        public int Sonuoc { get => sonuoc; set => sonuoc = value; }
        private string name=" ";
        public string Name { get => name; set => name = value; }
        private string mode=" ";
        public string Mode { get => mode; set => mode = value; }

        #endregion

        #region Intitialize
        public ChessBoardsetup(Panel banco,TextBox nuocdi1,TextBox playername, TextBox mode)
        {
            this.banco = banco;
            this.nuocdi = nuocdi1;


            //tao ra 2 nguoi choi
            this.Player = new List<Player>()
            {
                 new Player(" ",Image.FromFile(Application.StartupPath+"\\Resources\\X.png"),0," "),
                 new Player("Máy",  Image.FromFile(Application.StartupPath+"\\Resources\\O.png"),0," ")
            };  

        }
        

        #endregion

         #region Methods
        public void vebanco()
        {
            sonuoc = 0;
            banco.Controls.Clear();
            CurrentPlayer = 0;
            //tao ma tran
            Matrix = new List<List<Button>>();
            if (Player[0].Mode == "Easy")
            {

                 ChieuNgangBC = cons.board_width - 4;
                 ChieuCaoBC = cons.board_height - 4;
            } if (Player[0].Mode == "Normal")
            {
                 ChieuNgangBC = cons.board_width - 2;
                 ChieuCaoBC = cons.board_height - 2;
            }


            //tao ra button truoc do
            Button oldbutton = new Button() { Width = 0, Location = new Point(0, 0) };
            for (int i = 0; i <= ChieuCaoBC; i++)
            {
                matrix.Add(new List<Button>());
                for (int j = 0; j <= ChieuNgangBC; j++)
                {
                    Button btn = new Button()
                    {
                        Width = cons.chess_width,
                        Height = cons.chess_heigh,
                        //lay vi tri cua oldbutton de xac dinh cho vi tri button lien ke
                        Location = new Point(oldbutton.Location.X + oldbutton.Width, oldbutton.Location.Y),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        //tag dung de xac dinh cot
                        Tag = i.ToString()
                    };

                    btn.Click += Btn_Click;

                    banco.Controls.Add(btn);

                    matrix[i].Add(btn);

                    oldbutton = btn;
                }
                //xuong hang, tao lai toa do moi cho oldbutton
                oldbutton.Location = new Point(0, oldbutton.Location.Y + cons.chess_heigh);
                oldbutton.Width = 0;
                oldbutton.Height = 0;
            }
        }

        //su ly su kien click va doi nguoi choi
        void Btn_Click(object sender, EventArgs e)
        {

            Button btn = sender as Button;
            if (btn.BackgroundImage != null)
                return;
            else sonuoc++;
            nuocdi.Text = getsonuoc().ToString();
            mark(btn);
            if (isEndgame(btn))
            {
                Endgame();
            }
            else
                if (currentPlayer == 0) {
                 May();
                }
        }

        private void May()
        {
            currentPlayer = 1;
            int DiemMax = 0;
            int DiemPhongNgu = 0;
            int DiemTanCong = 0;
            int X = 0;
            int Y = 0;

            if (Player[0].Mode == "Easy")
            {

            }
            if (Player[0].Mode == "Normal")
            {
                ChieuNgangBC = cons.board_width - 2;
                ChieuCaoBC = cons.board_height - 2;
            }

            //nuoc di dau tien cua may luon danh o trung tam
            if (sonuoc == 1)
            {
                if(matrix[ChieuCaoBC / 2][ChieuNgangBC / 2].BackgroundImage == null)
                    mark(matrix[ChieuCaoBC / 2][ChieuNgangBC / 2]);
                else mark(matrix[(ChieuCaoBC / 2)-1][ChieuNgangBC / 2]);
            }
            else //thuật toán minmax tìm điểm cao nhất để đánh
            {
                for (int i = 0; i <= ChieuCaoBC; i++)
                {
                    for (int j = 0; j <= ChieuNgangBC; j++)
                    {
                        if (matrix[i][j].BackgroundImage == null && !cattia(matrix[i][j]))
                        {
                            int DiemTam;

                            if (Player[0].Mode == "Easy")
                            {
                                DiemTanCong = duyetTC_Ngang(i, j) + duyetTC_Doc(i, j) + duyetTC_CheoChinh(i, j) + duyetTC_CheoPhu(i, j);
                                DiemPhongNgu = 0;
                            }
                            if (Player[0].Mode == "Normal")
                            {
                                DiemTanCong = 0;
                                DiemPhongNgu = duyetPN_Ngang(i, j) + duyetPN_Doc(i, j) + duyetPN_CheoChinh(i, j) + duyetPN_CheoPhu(i, j);
                            }
                            if (Player[0].Mode == "Hard") 
                            {
                                DiemTanCong = duyetTC_Ngang(i, j) + duyetTC_Doc(i, j) + duyetTC_CheoChinh(i, j) + duyetTC_CheoPhu(i, j);
                                DiemPhongNgu = duyetPN_Ngang(i, j) + duyetPN_Doc(i, j) + duyetPN_CheoChinh(i, j) + duyetPN_CheoPhu(i, j);
                            }

                            if (DiemPhongNgu > DiemTanCong)
                            {
                                DiemTam = DiemPhongNgu;
                            }
                            else
                            {
                                DiemTam = DiemTanCong;
                            }

                            if (DiemMax < DiemTam)
                            {
                                DiemMax = DiemTam;
                                Y = i; X = j;
                            }
                        }
                    }
                }
                currentPlayer = 1;
                mark(matrix[Y][X]);
                if (isEndgame(matrix[Y][X]))
                {
                    Endgame();
                }
            }
            currentPlayer = 0;
        }


        #region Cắt tỉa Apha Beta
        public bool cattia(Button btn)
        {
            if (catTiaNgang(btn) && catTiaDoc(btn) && catTiaCheoChinh(btn) && catTiaCheoPhu(btn))
                return true;

            //chạy đến đây thì 1 trong 4 hướng vẫn có nước cờ thì không được cắt tỉa
            return false;
        }
        public bool catTiaNgang(Button btn)
        {
            Point point = getchesspoint(btn);
            //Cắt tỉa phải
            if (point.X <= ChieuNgangBC - 5)
                for (int i = 1; i <= 4; i++)
                    if (matrix[point.Y][point.X + i].BackgroundImage != null)//nếu có nước cờ thì không cắt tỉa
                        return false;
            //Cắt tỉa trái
            if (point.X >= 4)
                for (int i = 1; i <= 4; i++)
                    if (matrix[point.Y][point.X - i].BackgroundImage != null)//nếu có nước cờ thì không cắt tỉa
                        return false;

            //nếu chạy đến đây tức duyệt 2 bên đều không có nước đánh thì cắt tỉa
            return true;
        }
        public bool catTiaDoc(Button btn)
        {
            Point point = getchesspoint(btn);
           
            //duyệt phía trên
            if (point.Y >= 4)
                for (int i = 1; i <= 4; i++)
                    if (matrix[point.Y-i][point.X].BackgroundImage != null)//nếu có nước cờ thì không cắt tỉa
                        return false;
            
            //duyệt phía dưới
            if (point.Y <= ChieuCaoBC - 5)
                for (int i = 1; i <= 4; i++)
                    if (matrix[point.Y+i][point.X].BackgroundImage != null)//nếu có nước cờ thì không cắt tỉa
                        return false;
           
            //nếu chạy đến đây tức duyệt 2 bên đều không có nước đánh thì cắt tỉa
            return true;
        }

        public bool catTiaCheoChinh(Button btn)
        {
            Point point = getchesspoint(btn);
            //duyệt từ trên xuống
            if (point.Y <= ChieuCaoBC - 5 && point.X <= ChieuNgangBC - 5)
                for (int i = 1; i <= 4; i++)
                    if (matrix[point.Y + i][point.X + i].BackgroundImage != null)//nếu có nước cờ thì không cắt tỉa
                        return false;
            //duyệt từ dưới lên

            if (point.X >= 4 && point.Y >= 4)
                for (int i = 1; i <= 4; i++)
                    if (matrix[point.Y - i][point.X - i].BackgroundImage != null)//nếu có nước cờ thì không cắt tỉa
                        return false;

            //nếu chạy đến đây tức duyệt 2 bên đều không có nước đánh thì cắt tỉa
            return true;
        }
        public bool catTiaCheoPhu(Button btn)
        {
            Point point = getchesspoint(btn);
            //duyệt từ trên xuống
            if (point.Y <= ChieuCaoBC - 5 && point.X >= 4)
                for (int i = 1; i <= 4; i++)
                    if (matrix[point.Y + i][point.X - i].BackgroundImage != null)//nếu có nước cờ thì không cắt tỉa
                        return false;
            
            //duyệt từ dưới lên
            if (point.X <= ChieuNgangBC - 5 && point.Y >= 4)
                for (int i = 1; i <= 4; i++)
                    if (matrix[point.Y - i][point.X + i].BackgroundImage != null)//nếu có nước cờ thì không cắt tỉa
                        return false;

            //nếu chạy đến đây tức duyệt 2 bên đều không có nước đánh thì cắt tỉa
            return true;
        }
        #endregion

        #region sử lý thắng thua 
        private void Endgame()
        {
            if (currentPlayer == 0)
            {
                MessageBox.Show(Player[0].Name + " Chiến thắng với " + sonuoc.ToString() + " bước");
            }
            else
            {
                MessageBox.Show(Player[1].Name + " Chiến thắng với " + sonuoc.ToString() + " bước");
            }
            //Savescore();
            reset();
            vebanco();
        }

        private bool isEndgame(Button btn)
        {
            return hangngang(btn) || hangdoc(btn) || hangcheochinh(btn) || hangcheophu(btn);
        }

        private Point getchesspoint(Button btn)
        {
            int vertical = Convert.ToInt32(btn.Tag);
            int horizontal = matrix[vertical].IndexOf(btn);

            Point point = new Point(horizontal,vertical);

            return point;
        }

        private bool hangngang(Button btn)
        {
            Point point = getchesspoint(btn);

            int countleft = 0;
            for(int i = point.X; i >= 0; i--)
            {
                if (matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    countleft++;
                }
                else break;
            }

            int countright= 0;
            for (int i = point.X+1; i <= ChieuNgangBC; i++)
            {
                if (matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    countright++;
                }
                else break;
            }
            if (countleft + countright > 5 || countleft + countright == 5)
                return true;
            else return false;
        }

        private bool hangdoc(Button btn)
        {
            Point point = getchesspoint(btn);

            int counttop = 0;

            for (int i = point.Y; i >= 0; i--)
            {
                if (matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    counttop++;
                }
                else break;
            }

            int countbottom = 0;
            for (int i = point.Y + 1; i <= ChieuCaoBC; i++)
            {
                if (matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    countbottom++;
                }
                else break;
            }
            if (counttop + countbottom > 5 || counttop + countbottom == 5)
                return true;
            else return false;
        }

        private bool hangcheochinh(Button btn)
        {
            Point point = getchesspoint(btn);

            int counttop = 0;
            for (int i = 0; i < point.X ; i++)
            {
                //kiem tra co ra khoi mang khong
                if (point.X - i < 0 || point.Y - i < 0)
                    break;

                if (matrix[point.Y - i][point.X - i].BackgroundImage == btn.BackgroundImage)
                {
                    counttop++;
                }
                else break;
            }

            int countbottom = 0;
            for (int i = 1; i <= ChieuNgangBC - point.X; i++)
            {
                //kiem tra co ra khoi mang khong
                if (point.Y + i > ChieuCaoBC || point.X + i > ChieuNgangBC)
                    break;
                if (matrix[point.Y + i][point.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    countbottom++;
                }
                else break;
            }
            if (counttop + countbottom > 5 || counttop + countbottom == 5)
                return true;
            else return false;
        }

        private bool hangcheophu(Button btn)
        {
            {
                Point point = getchesspoint(btn);

                int counttop = 0;
                for (int i = 0; i < point.X; i++)
                {

                    //kiem tra co ra khoi mang khong
                    if (point.X + i > ChieuNgangBC|| point.Y - i < 0)
                        break;
                    if (matrix[point.Y - i][point.X + i].BackgroundImage == btn.BackgroundImage)
                    {
                        counttop++;
                    }
                    else break;
                }

                int countbottom = 0;
                for (int i = 1; i <= ChieuNgangBC - point.X; i++)
                {
                    //kiem tra co ra khoi mang khong
                    if (point.Y + i > ChieuCaoBC || point.X - i < 0)
                        break;

                    if (matrix[point.Y + i][point.X - i].BackgroundImage == btn.BackgroundImage)
                    {
                        countbottom++;
                    }
                    else break;
                }
                if (counttop + countbottom > 5 || counttop + countbottom == 5)
                    return true;
                else return false;
            }

        }
        #endregion

        #region Bot
        private int[] MangDiemTanCong = new int[7] { 0, 4, 25, 246, 7300, 6561, 59049 };
        private int[] MangDiemPhongNgu = new int[7] { 0, 3, 24, 243, 2197, 19773, 177957 };

        //duyệt ngang
        public int duyetTC_Ngang(int Y, int X)
        {
            int DiemTanCong = 0;
            int SoQuanTa = 0;
            int SoQuanDichPhai = 0;
            int SoQuanDichTrai = 0;
            int KhoangChong = 0;

            //bên phải
            for (int dem = 1; dem <= 4 && X < ChieuNgangBC - 5; dem++)
            {
                if (matrix[Y][X + dem].BackgroundImage == player[1].Mark)
                {
                    if (dem == 1)
                        DiemTanCong += 37;

                    SoQuanTa++;
                    KhoangChong++;
                }
                else
                    if (matrix[Y][X + dem].BackgroundImage == player[0].Mark)
                {
                    SoQuanDichPhai++;
                    break;
                }
                else KhoangChong++;
            }
            //bên trái
            for (int dem = 1; dem <= 4 && X > 4; dem++)
            {
                if (matrix[Y][X - dem].BackgroundImage == player[1].Mark)
                {
                    if (dem == 1)
                        DiemTanCong += 37;

                    SoQuanTa++;
                    KhoangChong++;

                }
                else
                    if (matrix[Y][X - dem].BackgroundImage == player[0].Mark)
                {
                    SoQuanDichTrai++;
                    break;
                }
                else KhoangChong++;
            }
            //bị chặn 2 đầu khoảng chống không đủ tạo thành 5 nước
            if (SoQuanDichPhai > 0 && SoQuanDichTrai > 0 && KhoangChong < 4)
                return 0;

            DiemTanCong -= MangDiemPhongNgu[SoQuanDichPhai + SoQuanDichTrai];
            DiemTanCong += MangDiemTanCong[SoQuanTa];
            return DiemTanCong;
        }

        //duyệt dọc
        public int duyetTC_Doc(int Y, int X)
        {
            int DiemTanCong = 0;
            int SoQuanTa = 0;
            int SoQuanDichTren = 0;
            int SoQuanDichDuoi = 0;
            int KhoangChong = 0;

            //bên trên
            for (int dem = 1; dem <= 4 && Y > 4; dem++)
            {
                if (matrix[Y - dem][X].BackgroundImage == player[1].Mark)
                {
                    if (dem == 1)
                        DiemTanCong += 37;

                    SoQuanTa++;
                    KhoangChong++;

                }
                else
                    if (matrix[Y - dem][X].BackgroundImage == player[0].Mark)
                {
                    SoQuanDichTren++;
                    break;
                }
                else KhoangChong++;
            }
            //bên dưới
            for (int dem = 1; dem <= 4 && Y < ChieuCaoBC - 5; dem++)
            {
                if (matrix[Y + dem][X].BackgroundImage == player[1].Mark)
                {
                    if (dem == 1)
                        DiemTanCong += 37;

                    SoQuanTa++;
                    KhoangChong++;

                }
                else
                    if (matrix[Y + dem][X].BackgroundImage == player[0].Mark)
                {
                    SoQuanDichDuoi++;
                    break;
                }
                else KhoangChong++;
            }
            //bị chặn 2 đầu khoảng chống không đủ tạo thành 5 nước
            if (SoQuanDichTren > 0 && SoQuanDichDuoi > 0 && KhoangChong < 4)
                return 0;

            DiemTanCong -= MangDiemPhongNgu[SoQuanDichTren + SoQuanDichDuoi];
            DiemTanCong += MangDiemTanCong[SoQuanTa];
            return DiemTanCong;
        }

        //Chéo chính
        public int duyetTC_CheoChinh(int Y, int X)
        {
            int DiemTanCong = 1;
            int SoQuanTa = 0;
            int SoQuanDichCheoTren = 0;
            int SoQuanDichCheoDuoi = 0;
            int KhoangChong = 0;

            //bên chéo xuôi xuống
            for (int dem = 1; dem <= 4 && X < ChieuNgangBC - 5 && Y < ChieuCaoBC - 5; dem++)
            {
                if (matrix[Y + dem][X + dem].BackgroundImage == player[1].Mark)
                {
                    if (dem == 1)
                        DiemTanCong += 37;

                    SoQuanTa++;
                    KhoangChong++;

                }
                else
                    if (matrix[Y + dem][X + dem].BackgroundImage == player[0].Mark)
                {
                    SoQuanDichCheoTren++;
                    break;
                }
                else KhoangChong++;
            }
            //chéo xuôi lên
            for (int dem = 1; dem <= 4 && Y > 4 && X > 4; dem++)
            {
                if (matrix[Y - dem][X - dem].BackgroundImage == player[1].Mark)
                {
                    if (dem == 1)
                        DiemTanCong += 37;

                    SoQuanTa++;
                    KhoangChong++;

                }
                else
                   if (matrix[Y - dem][X - dem].BackgroundImage == player[0].Mark)
                {
                    SoQuanDichCheoDuoi++;
                    break;
                }
                else KhoangChong++;
            }
            //bị chặn 2 đầu khoảng chống không đủ tạo thành 5 nước
            if (SoQuanDichCheoTren > 0 && SoQuanDichCheoDuoi > 0 && KhoangChong < 4)
                return 0;

            DiemTanCong -= MangDiemPhongNgu[SoQuanDichCheoTren + SoQuanDichCheoDuoi];
            DiemTanCong += MangDiemTanCong[SoQuanTa];
            return DiemTanCong;
        }

        //chéo Phu
        public int duyetTC_CheoPhu(int Y, int X)
        {
            int DiemTanCong = 0;
            int SoQuanTa = 0;
            int SoQuanDichCheoTren = 0;
            int SoQuanDichCheoDuoi = 0;
            int KhoangChong = 0;

            //chéo ngược lên
            for (int dem = 1; dem <= 4 && X < ChieuNgangBC - 5 && Y > 4; dem++)
            {
                if (matrix[Y - dem][X + dem].BackgroundImage == player[1].Mark)
                {
                    if (dem == 1)
                        DiemTanCong += 37;

                    SoQuanTa++;
                    KhoangChong++;

                }
                else
                    if (matrix[Y - dem][X + dem].BackgroundImage == player[0].Mark)
                {
                    SoQuanDichCheoTren++;
                    break;
                }
                else KhoangChong++;
            }
            //chéo ngược xuống
            for (int dem = 1; dem <= 4 && X > 4 && Y < ChieuCaoBC - 5; dem++)
            {
                if (matrix[Y + dem][X - dem].BackgroundImage == player[1].Mark)
                {
                    if (dem == 1)
                        DiemTanCong += 37;

                    SoQuanTa++;
                    KhoangChong++;

                }
                else
                    if (matrix[Y + dem][X - dem].BackgroundImage == player[0].Mark)
                {
                    SoQuanDichCheoDuoi++;
                    break;
                }
                else KhoangChong++;
            }
            //bị chặn 2 đầu khoảng chống không đủ tạo thành 5 nước
            if (SoQuanDichCheoTren > 0 && SoQuanDichCheoDuoi > 0 && KhoangChong < 4)
                return 0;

            DiemTanCong -= MangDiemPhongNgu[SoQuanDichCheoTren + SoQuanDichCheoDuoi];
            DiemTanCong += MangDiemTanCong[SoQuanTa];
            return DiemTanCong;
        }

        //duyệt ngang
        public int duyetPN_Ngang(int Y, int X)
        {
            int DiemPhongNgu = 0;
            int SoQuanTaTrai = 0;
            int SoQuanTaPhai = 0;
            int SoQuanDich = 0;
            int KhoangChongPhai = 0;
            int KhoangChongTrai = 0;
            bool ok = false;


            for (int dem = 1; dem <= 4 && X < ChieuNgangBC - 5; dem++)
            {
                if (matrix[Y][X + dem].BackgroundImage == player[0].Mark)
                {
                    if (dem == 1)
                        DiemPhongNgu += 9;

                    SoQuanDich++;
                }
                else
                    if (matrix[Y][X + dem].BackgroundImage == player[1].Mark)
                {
                    if (dem == 4)
                        DiemPhongNgu -= 170;

                    SoQuanTaTrai++;
                    break;
                }
                else
                {
                    if (dem == 1)
                        ok = true;

                    KhoangChongPhai++;
                }
            }

            if (SoQuanDich == 3 && KhoangChongPhai == 1 && ok)
                DiemPhongNgu -= 200;

            ok = false;

            for (int dem = 1; dem <= 4 && X > 4; dem++)
            {
                if (matrix[Y][X - dem].BackgroundImage == player[0].Mark)
                {
                    if (dem == 1)
                        DiemPhongNgu += 9;

                    SoQuanDich++;
                }
                else
                    if (matrix[Y][X - dem].BackgroundImage == player[1].Mark)
                {
                    if (dem == 4)
                        DiemPhongNgu -= 170;

                    SoQuanTaPhai++;
                    break;
                }
                else
                {
                    if (dem == 1)
                        ok = true;

                    KhoangChongTrai++;
                }
            }

            if (SoQuanDich == 3 && KhoangChongTrai == 1 && ok)
                DiemPhongNgu -= 200;

            if (SoQuanTaPhai > 0 && SoQuanTaTrai > 0 && (KhoangChongTrai + KhoangChongPhai + SoQuanDich) < 4)
                return 0;

            DiemPhongNgu -= MangDiemTanCong[SoQuanTaPhai + SoQuanTaPhai];
            DiemPhongNgu += MangDiemPhongNgu[SoQuanDich];

            return DiemPhongNgu;
        }

        //duyệt dọc
        public int duyetPN_Doc(int Y, int X)
        {
            int DiemPhongNgu = 0;
            int SoQuanTaTrai = 0;
            int SoQuanTaPhai = 0;
            int SoQuanDich = 0;
            int KhoangChongTren = 0;
            int KhoangChongDuoi = 0;
            bool ok = false;

            //lên
            for (int dem = 1; dem <= 4 && Y > 4; dem++)
            {
                if (matrix[Y - dem][X].BackgroundImage == player[0].Mark)
                {
                    if (dem == 1)
                        DiemPhongNgu += 9;

                    SoQuanDich++;

                }
                else
                    if (matrix[Y - dem][X].BackgroundImage == player[1].Mark)
                {
                    if (dem == 4)
                        DiemPhongNgu -= 170;

                    SoQuanTaPhai++;
                    break;
                }
                else
                {
                    if (dem == 1)
                        ok = true;

                    KhoangChongTren++;
                }
            }

            if (SoQuanDich == 3 && KhoangChongTren == 1 && ok)
                DiemPhongNgu -= 200;

            ok = false;
            //xuống
            for (int dem = 1; dem <= 4 && Y < ChieuCaoBC - 5; dem++)
            {
                //gặp quân địch
                if (matrix[Y + dem][X].BackgroundImage == player[0].Mark)
                {
                    if (dem == 1)
                        DiemPhongNgu += 9;

                    SoQuanDich++;
                }
                else
                    if (matrix[Y + dem][X].BackgroundImage == player[1].Mark)
                {
                    if (dem == 4)
                        DiemPhongNgu -= 170;

                    SoQuanTaTrai++;
                    break;
                }
                else
                {
                    if (dem == 1)
                        ok = true;

                    KhoangChongDuoi++;
                }
            }

            if (SoQuanDich == 3 && KhoangChongDuoi == 1 && ok)
                DiemPhongNgu -= 200;

            if (SoQuanTaPhai > 0 && SoQuanTaTrai > 0 && (KhoangChongTren + KhoangChongDuoi + SoQuanDich) < 4)
                return 0;

            DiemPhongNgu -= MangDiemTanCong[SoQuanTaTrai + SoQuanTaPhai];
            DiemPhongNgu += MangDiemPhongNgu[SoQuanDich];
            return DiemPhongNgu;
        }

        //chéo xuôi
        public int duyetPN_CheoChinh(int Y, int X)
        {
            int DiemPhongNgu = 0;
            int SoQuanTaTrai = 0;
            int SoQuanTaPhai = 0;
            int SoQuanDich = 0;
            int KhoangChongTren = 0;
            int KhoangChongDuoi = 0;
            bool ok = false;

            //lên
            for (int dem = 1; dem <= 4 && Y < ChieuCaoBC - 5 && X < ChieuNgangBC - 5; dem++)
            {
                if (matrix[Y + dem][X + dem].BackgroundImage == player[0].Mark)
                {
                    if (dem == 1)
                        DiemPhongNgu += 9;

                    SoQuanDich++;
                }
                else
                    if (matrix[Y + dem][X + dem].BackgroundImage == player[1].Mark)
                {
                    if (dem == 4)
                        DiemPhongNgu -= 170;

                    SoQuanTaPhai++;
                    break;
                }
                else
                {
                    if (dem == 1)
                        ok = true;

                    KhoangChongTren++;
                }
            }

            if (SoQuanDich == 3 && KhoangChongTren == 1 && ok)
                DiemPhongNgu -= 200;

            ok = false;
            //xuống
            for (int dem = 1; dem <= 4 && Y > 4 && X > 4; dem++)
            {
                if (matrix[Y - dem][X - dem].BackgroundImage == player[0].Mark)
                {
                    if (dem == 1)
                        DiemPhongNgu += 9;

                    SoQuanDich++;
                }
                else
                    if (matrix[Y - dem][X - dem].BackgroundImage == player[1].Mark)
                {
                    if (dem == 4)
                        DiemPhongNgu -= 170;

                    SoQuanTaTrai++;
                    break;
                }
                else
                {
                    if (dem == 1)
                        ok = true;

                    KhoangChongDuoi++;
                }
            }

            if (SoQuanDich == 3 && KhoangChongDuoi == 1 && ok)
                DiemPhongNgu -= 200;

            if (SoQuanTaPhai > 0 && SoQuanTaTrai > 0 && (KhoangChongTren + KhoangChongDuoi + SoQuanDich) < 4)
                return 0;

            DiemPhongNgu -= MangDiemTanCong[SoQuanTaPhai + SoQuanTaTrai];
            DiemPhongNgu += MangDiemPhongNgu[SoQuanDich];

            return DiemPhongNgu;
        }

        //chéo phu
        public int duyetPN_CheoPhu(int Y, int X)
        {
            int DiemPhongNgu = 0;
            int SoQuanTaTrai = 0;
            int SoQuanTaPhai = 0;
            int SoQuanDich = 0;
            int KhoangChongTren = 0;
            int KhoangChongDuoi = 0;
            bool ok = false;

            //lên
            for (int dem = 1; dem <= 4 && Y > 4 && X < ChieuNgangBC - 5; dem++)
            {

                if (matrix[Y - dem][X + dem].BackgroundImage == player[0].Mark)
                {
                    if (dem == 1)
                        DiemPhongNgu += 9;

                    SoQuanDich++;
                }
                else
                    if (matrix[Y - dem][X + dem].BackgroundImage == player[1].Mark)
                {
                    if (dem == 4)
                        DiemPhongNgu -= 170;

                    SoQuanTaPhai++;
                    break;
                }
                else
                {
                    if (dem == 1)
                        ok = true;

                    KhoangChongTren++;
                }
            }


            if (SoQuanDich == 3 && KhoangChongTren == 1 && ok)
                DiemPhongNgu -= 200;

            ok = false;

            //xuống
            for (int dem = 1; dem <= 4 && Y < ChieuCaoBC - 5 && X > 4; dem++)
            {
                if (matrix[Y + dem][X - dem].BackgroundImage == player[0].Mark)
                {
                    if (dem == 1)
                        DiemPhongNgu += 9;

                    SoQuanDich++;
                }
                else
                    if (matrix[Y + dem][X - dem].BackgroundImage == player[1].Mark)
                {
                    if (dem == 4)
                        DiemPhongNgu -= 170;

                    SoQuanTaTrai++;
                    break;
                }
                else
                {
                    if (dem == 1)
                        ok = true;

                    KhoangChongDuoi++;
                }
            }

            if (SoQuanDich == 3 && KhoangChongDuoi == 1 && ok)
                DiemPhongNgu -= 200;

            if (SoQuanTaPhai > 0 && SoQuanTaTrai > 0 && (KhoangChongTren + KhoangChongDuoi + SoQuanDich) < 4)
                return 0;

            DiemPhongNgu -= MangDiemTanCong[SoQuanTaTrai + SoQuanTaPhai];
            DiemPhongNgu += MangDiemPhongNgu[SoQuanDich];

            return DiemPhongNgu;
        }
        #endregion

        #region hàm lẻ tẻ
        private void mark(Button btn)
        {
            btn.BackgroundImage = Player[CurrentPlayer].Mark;
        }
        public void reset()
        {
            banco.Controls.Clear();
            sonuoc = 0;
            nuocdi.Text = getsonuoc();
        }

        private string getsonuoc()
        {
            return sonuoc.ToString();
        }

        private void Savescore()
        {
            conn = new SqlConnection("Server = DESKTOP-VGDTGBM\\MSSQLSERVER01;Initial Catalog=BanDiemCoCaro;Trusted_Connection=True;");
            commd = new SqlCommand("Select * From DiemCoCaro", conn);
            conn.Open();
            try
            {
                commd = new SqlCommand("Select max(Lan_Choi) from DiemCoCaro", conn);
                try
                {
                    lanchoi = Convert.ToInt32(commd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    lanchoi = 0;
                }
                lanchoi++;
                sqlstr = "Insert into DiemCoCaRo Values (" + lanchoi + ",N'" + Player[currentPlayer].Name + "','" + sonuoc + "','" + player[0].Mode + "')";
                MessageBox.Show(sqlstr);
                commd = new SqlCommand(sqlstr, conn);
                commd.ExecuteNonQuery();
                MessageBox.Show("Đã thêm vào cơ sơ dữ liệu, chọn bảng điểm đễ xem", "thêm điểm thành công", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        #endregion
        #endregion
    }
}
