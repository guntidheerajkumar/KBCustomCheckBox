using System;
using System.Collections.Generic;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace KBCustomCheckBox
{
	// @interface KBAnimationManager : NSObject
	[BaseType(typeof(NSObject))]
	interface KBAnimationManager
	{
		// @property (nonatomic) CGFloat animationDuration;
		[Export("animationDuration")]
		nfloat AnimationDuration { get; set; }

		// -(instancetype)initWithAnimationDuration:(CGFloat)animationDuration;
		[Export("initWithAnimationDuration:")]
		IntPtr Constructor(nfloat animationDuration);

		// -(CABasicAnimation *)strokeAnimationReverse:(BOOL)reverse;
		[Export("strokeAnimationReverse:")]
		CABasicAnimation StrokeAnimationReverse(bool reverse);

		// -(CABasicAnimation *)opacityAnimationReverse:(BOOL)reverse;
		[Export("opacityAnimationReverse:")]
		CABasicAnimation OpacityAnimationReverse(bool reverse);

		// -(CABasicAnimation *)morphAnimationFromPath:(UIBezierPath *)fromPath toPath:(UIBezierPath *)toPath;
		[Export("morphAnimationFromPath:toPath:")]
		CABasicAnimation MorphAnimationFromPath(UIBezierPath fromPath, UIBezierPath toPath);

		// -(CAKeyframeAnimation *)fillAnimationWithBounces:(NSUInteger)bounces amplitude:(CGFloat)amplitude reverse:(BOOL)reverse;
		[Export("fillAnimationWithBounces:amplitude:reverse:")]
		CAKeyFrameAnimation FillAnimationWithBounces(nuint bounces, nfloat amplitude, bool reverse);
	}

	// @interface KBCheckBoxGroup : NSObject
	[BaseType(typeof(NSObject))]
	interface KBCheckBoxGroup
	{
		//// @property (readonly, nonatomic, strong) NSOrderedSet<KBCheckBox *> * _Nonnull checkBoxes;
		//[Export("checkBoxes", ArgumentSemantic.Strong)]
		//List<KBCheckBox> CheckBoxes { get; }

		// @property (nonatomic, strong) KBCheckBox * _Nullable selectedCheckBox;
		[NullAllowed, Export("selectedCheckBox", ArgumentSemantic.Strong)]
		KBCheckBox SelectedCheckBox { get; set; }

		// @property (nonatomic) BOOL mustHaveSelection;
		[Export("mustHaveSelection")]
		bool MustHaveSelection { get; set; }

		// +(instancetype _Nonnull)groupWithCheckBoxes:(NSArray<KBCheckBox *> * _Nullable)checkBoxes;
		[Static]
		[Export("groupWithCheckBoxes:")]
		KBCheckBoxGroup GroupWithCheckBoxes([NullAllowed] KBCheckBox[] checkBoxes);

		// -(void)addCheckBoxToGroup:(KBCheckBox * _Nonnull)checkBox;
		[Export("addCheckBoxToGroup:")]
		void AddCheckBoxToGroup(KBCheckBox checkBox);

		// -(void)removeCheckBoxFromGroup:(KBCheckBox * _Nonnull)checkBox;
		[Export("removeCheckBoxFromGroup:")]
		void RemoveCheckBoxFromGroup(KBCheckBox checkBox);
	}

	// @interface KBCheckBox : UIControl <CAAnimationDelegate>
	[BaseType(typeof(UIControl))]
	interface KBCheckBox 
	{
		[Wrap("WeakDelegate")]
		[NullAllowed]
		KBCheckBoxDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<KBCheckBoxDelegate> _Nullable delegate __attribute__((iboutlet));
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (nonatomic) BOOL on;
		[Export("on")]
		bool On { get; set; }

		// @property (nonatomic) CGFloat lineWidth;
		[Export("lineWidth")]
		nfloat LineWidth { get; set; }

		// @property (nonatomic) CGFloat animationDuration;
		[Export("animationDuration")]
		nfloat AnimationDuration { get; set; }

		// @property (nonatomic) BOOL hideBox;
		[Export("hideBox")]
		bool HideBox { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull onTintColor;
		[Export("onTintColor", ArgumentSemantic.Strong)]
		UIColor OnTintColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull onFillColor;
		[Export("onFillColor", ArgumentSemantic.Strong)]
		UIColor OnFillColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull onCheckColor;
		[Export("onCheckColor", ArgumentSemantic.Strong)]
		UIColor OnCheckColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull tintColor;
		[Export("tintColor", ArgumentSemantic.Strong)]
		UIColor TintColor { get; set; }

		// @property (readonly, nonatomic, weak) KBCheckBoxGroup * _Nullable group;
		[NullAllowed, Export("group", ArgumentSemantic.Weak)]
		KBCheckBoxGroup Group { get; }

		// @property (nonatomic) KBBoxType boxType;
		[Export("boxType", ArgumentSemantic.Assign)]
		KBBoxType BoxType { get; set; }

		// @property (nonatomic) KBAnimationType onAnimationType;
		[Export("onAnimationType", ArgumentSemantic.Assign)]
		KBAnimationType OnAnimationType { get; set; }

		// @property (nonatomic) KBAnimationType offAnimationType;
		[Export("offAnimationType", ArgumentSemantic.Assign)]
		KBAnimationType OffAnimationType { get; set; }

		// @property (assign, nonatomic) CGSize minimumTouchSize;
		[Export("minimumTouchSize", ArgumentSemantic.Assign)]
		CGSize MinimumTouchSize { get; set; }

		// -(void)setOn:(BOOL)on animated:(BOOL)animated;
		[Export("setOn:animated:")]
		void SetOn(bool on, bool animated);

		// -(void)reload;
		[Export("reload")]
		void Reload();
	}

	// @protocol KBCheckBoxDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface KBCheckBoxDelegate
	{
		// @optional -(void)didTapCheckBox:(KBCheckBox * _Nonnull)checkBox;
		[Export("didTapCheckBox:")]
		void DidTapCheckBox(KBCheckBox checkBox);

		// @optional -(void)animationDidStopForCheckBox:(KBCheckBox * _Nonnull)checkBox;
		[Export("animationDidStopForCheckBox:")]
		void AnimationDidStopForCheckBox(KBCheckBox checkBox);
	}

	// @interface KBPathManager : NSObject
	[BaseType(typeof(NSObject))]
	interface KBPathManager
	{
		// @property (nonatomic) CGFloat size;
		[Export("size")]
		nfloat Size { get; set; }

		// @property (nonatomic) CGFloat lineWidth;
		[Export("lineWidth")]
		nfloat LineWidth { get; set; }

		// @property (nonatomic) KBBoxType boxType;
		[Export("boxType", ArgumentSemantic.Assign)]
		KBBoxType BoxType { get; set; }

		// -(UIBezierPath *)pathForBox;
		[Export("pathForBox")]
		UIBezierPath PathForBox { get; }

		// -(UIBezierPath *)pathForCheckMark;
		[Export("pathForCheckMark")]
		UIBezierPath PathForCheckMark { get; }

		// -(UIBezierPath *)pathForLongCheckMark;
		[Export("pathForLongCheckMark")]
		UIBezierPath PathForLongCheckMark { get; }

		// -(UIBezierPath *)pathForFlatCheckMark;
		[Export("pathForFlatCheckMark")]
		UIBezierPath PathForFlatCheckMark { get; }
	}
}
