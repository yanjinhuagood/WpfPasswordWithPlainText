using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfPasswrod.CustomControls
{
    /// <summary>
    /// PasswordWithPlainText.xaml 的交互逻辑
    /// </summary>
    public partial class PasswordWithPlainText : UserControl
    {
        public PasswordWithPlainText()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 图标
        /// </summary>
        public static readonly DependencyProperty IconImageProperty =
                             DependencyProperty.Register("IconImage", typeof(ImageSource), typeof(PasswordWithPlainText), new PropertyMetadata(new BitmapImage(new Uri("pack://application:,,,/Resources/Lock_48px.png"))));
        /// <summary>
        /// 图标
        /// </summary>
        public ImageSource IconImage
        {
            get { return (ImageSource)GetValue(IconImageProperty); }
            set { SetValue(IconImageProperty, value); }
        }
        /// <summary>
        /// 文本框提示文字
        /// </summary>
        public string Hint
        {
            get { return (string)GetValue(HintProperty); }
            set { SetValue(HintProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Hint.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HintProperty =
            DependencyProperty.Register("Hint", typeof(string), typeof(PasswordWithPlainText), new PropertyMetadata(null));
        /// <summary>
        /// 获取或设置水印背景的水平对齐方式
        /// </summary>
        public AlignmentX AlignmentX
        {
            get { return (AlignmentX)GetValue(AlignmentXProperty); }
            set { SetValue(AlignmentXProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AlignmentX.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AlignmentXProperty =
            DependencyProperty.Register("AlignmentX", typeof(AlignmentX), typeof(PasswordWithPlainText), new PropertyMetadata(AlignmentX.Left));
        /// <summary>
        /// 获取或设置密码
        /// </summary>
        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Password.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(PasswordWithPlainText), new PropertyMetadata(null));
        /// <summary>
        /// 获取或设置光标颜色
        /// </summary>
        public Brush CaretBrush
        {
            get { return (Brush)GetValue(CaretBrushProperty); }
            set { SetValue(CaretBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CaretBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CaretBrushProperty =
            DependencyProperty.Register("CaretBrush", typeof(Brush), typeof(PasswordWithPlainText), new PropertyMetadata(Brushes.Black));

        /// <summary>
        /// 获取或设置光标颜色
        /// </summary>
        public Brush BorderBrush
        {
            get { return (Brush)GetValue(BorderBrushProperty); }
            set { SetValue(BorderBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CaretBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BorderBrushProperty =
            DependencyProperty.Register("BorderBrush", typeof(Brush), typeof(PasswordWithPlainText), new PropertyMetadata(Brushes.Black));


        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(PasswordWithPlainText),
                                                                            new PropertyMetadata(new CornerRadius(0, 0, 0, 0), OnCornerRadiusChanged));
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set
            {
                SetValue(CornerRadiusProperty, value);
            }
        }

        private static void OnCornerRadiusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CornerRadius cornerRadius = new CornerRadius();
            cornerRadius = (CornerRadius)e.NewValue;
        }

        /// <summary>
        /// 切换成明文
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
       
        private void ImageRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            pwdCiphertext.Visibility = Visibility.Collapsed;
            tbPlainText.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// 切换成密文
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageRadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            pwdCiphertext.Visibility = Visibility.Visible;
            tbPlainText.Visibility = Visibility.Collapsed;
        }
        private void pwdCiphertext_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox pwd = sender as PasswordBox;
            if (pwd != null)
            {
                if (!string.IsNullOrEmpty(pwd.Password))
                {
                    pwd.Background = Brushes.Transparent;
                }
                else
                {
                    pwd.Background = (Brush)FindResource("HelpBrush");
                }
            }
        }

       
    }
}
