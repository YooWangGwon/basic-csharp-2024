// project : ex16_winforms
// date : 240415
// desc : window forms

using System.Security.Policy;

namespace ex16_winforms
{

    class MainApp : Form
    {
        static void Main(string[] args)
        {
            MainApp form = new MainApp();   // 새로 객체 생성

            form.Click += Form_Click;
            form.KeyPress += Form_KeyPress;
            form.Scroll += Form_Scroll;
            form.MouseMove += Form_MouseMove;
            form.MouseLeave += Form_MouseLeave;
            form.MouseWheel += Form_MouseWheel;

            Console.WriteLine("프로그램 시작!");
            Application.Run(form);

            Console.WriteLine("프로그램 종료!");
            //MyForm form = new MyForm();
            //form.Click += new EventHandler(
            //    (sender, eventArgs) =>
            //    {
            //        Application.Exit();
            //    });
            //Application.Run(form);
//            Application.Run(new MainApp());
        }

        private static void Form_MouseWheel(object? sender, MouseEventArgs e)
        {
            Console.WriteLine("마우스 휠 작동중");
        }

        private static void Form_MouseLeave(object? sender, EventArgs e)
        {
            Console.WriteLine("마우스가 떠남");
        }

        static int n = 0;
        private static void Form_MouseMove(object? sender, MouseEventArgs e)
        {
            Console.WriteLine($"마우스 움직이는 중{n}");
            n++;
        }

        private static void Form_Scroll(object? sender, ScrollEventArgs e)
        {
            Console.WriteLine("드래그 하는 중");
        }

        private static void Form_KeyPress(object? sender, KeyPressEventArgs e)
        {
            Console.Write($"{e.KeyChar} "); 
            Console.WriteLine("키보드 클릭!");
        }

        private static void Form_Click(object? sender, EventArgs e) //  윈도우가 만들어둔 이벤트 핸들러
        {
            Console.WriteLine("프로그램 종료 중...");
            Application.Exit();
        }
    }
}
