
#import <UIKit/UIKit.h>
#import "KBCheckBoxGroup.h"

@protocol KBCheckBoxDelegate;

/** The different type of boxes available.
 * @see boxType
 */
typedef NS_ENUM(NSInteger, KBBoxType) {
    /** Circled box.
     */
    KBBoxTypeCircle,
    
    /** Squared box.
     */
    KBBoxTypeSquare
};

// Tell the compiler to assume that no method should have a NULL value
NS_ASSUME_NONNULL_BEGIN

/**  Tasteful Checkbox for iOS.
 */
#if __IPHONE_OS_VERSION_MAX_ALLOWED > __IPHONE_9_3
IB_DESIGNABLE @interface KBCheckBox : UIControl <CAAnimationDelegate>
#else
IB_DESIGNABLE @interface KBCheckBox : UIControl
#endif

/** The different type of animations available.
 * @see onAnimationType and offAnimationType.
 */
typedef NS_ENUM(NSInteger, KBAnimationType) {
    /** Animates the box and the check as if they were drawn.
     *  Should be used with a clear colored onFillColor property.
     */
    KBAnimationTypeStroke,
    
    /** When tapped, the checkbox is filled from its center.
     * Should be used with a colored onFillColor property.
     */
    KBAnimationTypeFill,
    
    /** Animates the check mark with a bouncy effect.
     */
    KBAnimationTypeBounce,
    
    /** Morphs the checkmark from a line.
     * Should be used with a colored onFillColor property.
     */
    KBAnimationTypeFlat,
    
    /** Animates the box and check as if they were drawn in one continuous line.
     * Should be used with a clear colored onFillColor property.
     */
    KBAnimationTypeOneStroke,
    
    /** When tapped, the checkbox is fading in or out (opacity).
     */
    KBAnimationTypeFade
};

/** The object that acts as the delegate of the receiving check box.
* @discussion The delegate must adopt the \p KBCheckBoxDelegate protocol. The delegate is not retained.
 */
@property (nonatomic, weak) IBOutlet id <KBCheckBoxDelegate> delegate;

/** This property allows you to retrieve and set (without animation) a value determining whether the KBCheckBox object is On or Off.
  * Default to NO.
 */
@property (nonatomic) IBInspectable BOOL on;

/** The width of the lines of the check mark and the box. Default to 2.0.
 */
@property (nonatomic) IBInspectable CGFloat lineWidth;

/** The duration in seconds of the animation when the check box switches from on and off. Default to 0.5.
 */
@property (nonatomic) IBInspectable CGFloat animationDuration;

/** BOOL to control if the box should be hidden or not. Defaults to NO.
 */
@property (nonatomic) IBInspectable BOOL hideBox;

/** The color of the line around the box when it is On.
 */
@property (strong, nonatomic) IBInspectable UIColor *onTintColor;

/** The color of the inside of the box when it is On.
 */
@property (strong, nonatomic) IBInspectable UIColor *onFillColor;

/** The color of the check mark when it is On.
 */
@property (strong, nonatomic) IBInspectable UIColor *onCheckColor;

/** The color of the box when the checkbox is Off.
 */
@property (strong, nonatomic) IBInspectable UIColor *tintColor;

/** The group this box is associated with.
 */
@property (weak, nonatomic, nullable, readonly) KBCheckBoxGroup *group;

/** The type of box.
 * @see KBBoxType. 
 */
@property (nonatomic) KBBoxType boxType;

/** The animation type when the check mark gets set to On.
 * @warning Some animations might not look as intended if the different colors of the control are not appropriatly configured.
 * @see KBAnimationType. 
 */
@property (nonatomic) KBAnimationType onAnimationType;

/** The animation type when the check mark gets set to Off.
 * @warning Some animations might not look as intended if the different colors of the control are not appropriatly configured.
 * @see KBAnimationType. 
 */
@property (nonatomic) KBAnimationType offAnimationType;

/** If the checkbox width or height is smaller than this value, the touch area will be increased. Allows for visually small checkboxes to still be easily tapped. Default: (44, 44)
 */
@property (assign, nonatomic) IBInspectable CGSize minimumTouchSize;

/** Set the state of the check box to On or Off, optionally animating the transition.
 */
- (void)setOn:(BOOL)on animated:(BOOL)animated;

/** Forces a redraw of the entire check box.
 * The current value of On is kept.
 */
- (void)reload;

@end


/** The KBCheckBoxDelegate protocol. Used to receive life cycle events.
 */
@protocol KBCheckBoxDelegate <NSObject>

@optional

/** Sent to the delegate every time the check box gets tapped.
 * @discussion This method gets triggered after the properties are updated (on), but before the animations, if any, are completed.
 * @seealso animationDidStopForCheckBox:
 * @param checkBox The KBCheckBox instance that has been tapped.
 */
- (void)didTapCheckBox:(KBCheckBox*)checkBox;


/** Sent to the delegate every time the check box finishes being animated.
 * @discussion This method gets triggered after the properties are updated (on), and after the animations are completed. It won't be triggered if no animations are started.
 * @seealso didTapCheckBox:
 * @param checkBox The KBCheckBox instance that was animated.
 */
- (void)animationDidStopForCheckBox:(KBCheckBox *)checkBox;

@end

NS_ASSUME_NONNULL_END
