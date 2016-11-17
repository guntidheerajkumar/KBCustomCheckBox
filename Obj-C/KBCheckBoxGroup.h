
#import <UIKit/UIKit.h>

@class KBCheckBox;

@interface KBCheckBoxGroup : NSObject

/** An array of check boxes in this group.
 */
@property (nonatomic, strong, nonnull, readonly) NSOrderedSet<KBCheckBox *> *checkBoxes;

/** The currently selected check box. Only can be nil if mustHaveSelection is NO. Setting this value will cause the other check boxes to deselect automatically.
 */
@property (nonatomic, strong, nullable) KBCheckBox *selectedCheckBox;

/** If YES, don't allow the user to unselect all options, must have single selection at all times. Default to NO.
 */
@property (nonatomic) BOOL mustHaveSelection;

/** Creates a new group with the list of check boxes.
 */
+ (nonnull instancetype)groupWithCheckBoxes:(nullable NSArray<KBCheckBox *> *)checkBoxes;

/** Adds a check box to this group. Check boxes can only belong to a single group, adding to a group removes it from its current group.
 */
- (void)addCheckBoxToGroup:(nonnull KBCheckBox *)checkBox;

/** Removes a check box from this group.
 */
- (void)removeCheckBoxFromGroup:(nonnull KBCheckBox *)checkBox;

@end
