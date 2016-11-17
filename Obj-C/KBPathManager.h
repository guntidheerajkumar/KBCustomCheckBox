

#import <UIKit/UIKit.h>
#import "KBCheckBox.h"

/** Path object used by KBCheckBox to generate paths.
 */
@interface KBPathManager : NSObject

/** The paths are assumed to be created in squares. 
 * This is the size of width, or height, of the paths that will be created.
 */
@property (nonatomic) CGFloat size;

/** The width of the lines on the created paths.
 */
@property (nonatomic) CGFloat lineWidth;

/** The type of box.
 * Depending on the box type, paths may be created differently
 * @see KBBoxType
 */
@property (nonatomic) KBBoxType boxType;

/** Returns a UIBezierPath object for the box of the checkbox
 * @returns The path of the box.
 */
- (UIBezierPath *)pathForBox;

/** Returns a UIBezierPath object for the checkmark of the checkbox
 * @returns The path of the checkmark.
 */
- (UIBezierPath *)pathForCheckMark;

/** Returns a UIBezierPath object for an extra long checkmark which is in contact with the box.
 * @returns The path of the checkmark.
 */
- (UIBezierPath *)pathForLongCheckMark;

/** Returns a UIBezierPath object for the flat checkmark of the checkbox
 * @see KBAnimationTypeFlat
 * @returns The path of the flat checkmark.
 */
- (UIBezierPath *)pathForFlatCheckMark;

@end
