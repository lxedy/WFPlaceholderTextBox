// Lee Devenney ~ Lxedy

using System.Drawing;
using System.Windows.Forms;

public class PlaceHolderTextBox : TextBox
{

  bool isPlaceHolder = true;
  string _placeHolderText;
  bool _isPasswordTextBox;
  public string PlaceHolderText
  {
    get { return _placeHolderText; }
    set
    {
      _placeHolderText = value;
     setPlaceholder();
    }
  }

  public bool IsPasswordTextBox
  {
    get { return _isPasswordTextBox; }
    set
    {
      _isPasswordTextBox = value;
    }
  }

  public new string Text
  {
    get => isPlaceHolder ? string.Empty : base.Text;
    set => base.Text = value;
  }

  private void setPlaceholder()
  {
    if (string.IsNullOrEmpty(base.Text))
    {
      if (_isPasswordTextBox)
        this.UseSystemPasswordChar = false;

      base.Text = PlaceHolderText;
      this.ForeColor = Color.Gray;
      this.Font = new Font(this.Font, FontStyle.Italic);
      isPlaceHolder = true;
    }
  }

  private void removePlaceHolder()
  {

    if (isPlaceHolder)
    {
      if (_isPasswordTextBox)
        this.UseSystemPasswordChar = true;

      base.Text = "";
      this.ForeColor = System.Drawing.SystemColors.WindowText;
      this.Font = new Font(this.Font, FontStyle.Regular);
      isPlaceHolder = false;
    }
  }

  public PlaceHolderTextBox()
  {
    GotFocus += removePlaceHolder;
    LostFocus += setPlaceholder;
  }

  private void setPlaceholder(object sender, EventArgs e)
  {
    setPlaceholder();
  }

  private void removePlaceHolder(object sender, EventArgs e)
  {
    removePlaceHolder();
  }
}
