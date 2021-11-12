# WFPlaceholderTextBox

This is a Windows Forms textbox component that allows set placeholder text to be shown inside of it!

## [FEATURES]

+ Placeholder disappears on focus!
+ PasswordChar support!
+ Placeholder has lighter shade and is italic than typed text! (Can be changed if wanted)

## [SOURCE CODE]

```cs
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
```

You will need to copy and paste this for use in step 2 of the installation instructions!

## [INSTRUCTIONS]

+ Step 1: Create a class called PlaceHolderTextBox.cs under your project in the solution explorer...

![Alt text](https://i.imgur.com/a7OXQDD.png)

+ Step 2: Paste the source code into the class - replacing all text inside of it...

![Alt text](https://i.imgur.com/mJavV4q.png)

+ Step 3: Build your solution...

![Alt text](https://i.imgur.com/WPAWUmn.png)

+ Step 4: Locate the component under {Project Name} Components tab in Toolbox...

![Alt text](https://i.imgur.com/ByYXRj5.png)

+ Step 5: You can find the Placeholder Propteries under the Misc tab in Properties...

![Alt text](https://i.imgur.com/Fv0lV8W.png)

## [CONCLUSION]

You will need to use a Visual Studio version later than 2013 in order for this to work as it was intended.
You are free to edit as you like, but don't forget to credit me for contributing to your project!

Thanks for reading! 😄
