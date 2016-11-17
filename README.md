# KBCustomCheckBox

Awesome checkbox which can be easily integrate in to our iOS application.

This is a binding project which is based on https://github.com/Boris-Em/BEMCheckBox.

###Usage 

```
KBCheckBox checkBox = new KBCheckBox();
checkBox.Frame = new CGRect(40, 40, 16, 16);
checkBox.BoxType = KBBoxType.Circle;
checkBox.Delegate = new CustomDelegate();
this.View.AddSubview(checkBox);
```

```
public class CustomDelegate : KBCheckBoxDelegate
{
	public override void DidTapCheckBox(KBCheckBox checkBox)
	{
		
	}
}
```

To know the state of the Check Box whether is selected or unselected
```
checkBox.On = True/False;
```
