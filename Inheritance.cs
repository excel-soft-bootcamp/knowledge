 public class Control
    {
        private int _height, _width;
        private string _toolTip;

        //Telescopic Constructor Chain
        public Control(int height)
        {
            this._height = height;
        }

        public Control(int height,int width):this(height)
        {
            
            this._width = width;
            
        }
        public Control(int height, int width,string toolTip):this(height,width)
        {
            
            this._toolTip = toolTip;

        }

        
       
    }
    //Window is-a Control
    public class Window :Control{

        #region members
        string _state,_title;
        public void Show() { }
        public void Hide() { }
        public void Minimize() { }
        public void Maximize() { }
#endregion

        public  Window(string state,string title,int height,int width,string toolTip):base(height,width,toolTip)
        {
            this._title = title;
            this._state = state;
        }




    }

    //TextBox is-a Control
    class TextBox :Control{

        
        private string _text;
        public void Edit() { }
        public void Clear() { }
        public TextBox(string text,int height,int width,string title ):base(height,width,title)
        {

        }

    }
    //Button is-a Control
    class Button:Control {

       
        private string _caption;
        public void Click() { }
        public Button(string caption,int height,int width,string title):base(height,width,title) {

            this._caption = caption;
        
        }
    }

    class MainClass
    {

        static void Main()
        {
            Window _window = new Window("Maximized", "Search Window", 100, 300, "Test Window");

        }
    }
}
