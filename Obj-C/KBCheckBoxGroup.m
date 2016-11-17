

#import "KBCheckBoxGroup.h"
#import "KBCheckBox.h"

@interface KBCheckBoxGroup ()

@property (nonatomic, strong, nonnull) NSOrderedSet<KBCheckBox *> *checkBoxes;

@end

/** Defines private methods that we can call on the check box.
 */
@interface KBCheckBox ()

@property (weak, nonatomic, nullable) KBCheckBoxGroup *group;

- (void)_setOn:(BOOL)on animated:(BOOL)animated notifyGroup:(BOOL)notifyGroup;

@end

@implementation KBCheckBoxGroup

- (instancetype)init {
    self = [super init];
    if (self) {
        _mustHaveSelection = NO;
        _checkBoxes = [NSOrderedSet orderedSet];
    }
    return self;
}

+ (nonnull instancetype)groupWithCheckBoxes:(nullable NSArray<KBCheckBox *> *)checkBoxes {
    KBCheckBoxGroup *group = [[KBCheckBoxGroup alloc] init];
    for (KBCheckBox *checkbox in checkBoxes) {
        [group addCheckBoxToGroup:checkbox];
    }
    
    return group;
}

- (void)addCheckBoxToGroup:(nonnull KBCheckBox *)checkBox {
    if (checkBox.group) {
        [checkBox.group removeCheckBoxFromGroup:checkBox];
    }
    
    [checkBox _setOn:NO animated:NO notifyGroup:NO];
    checkBox.group = self;
    NSMutableOrderedSet *mutableBoxes = [self.checkBoxes mutableCopy];
    [mutableBoxes addObject:checkBox];
    self.checkBoxes = [NSOrderedSet orderedSetWithOrderedSet:mutableBoxes];
}

- (void)removeCheckBoxFromGroup:(nonnull KBCheckBox *)checkBox {
    if (![self.checkBoxes containsObject:checkBox]) {
        // Not in this group
        return;
    }
    
    checkBox.group = nil;
    NSMutableOrderedSet *mutableBoxes = [self.checkBoxes mutableCopy];
    [mutableBoxes removeObject:checkBox];
    self.checkBoxes = [NSOrderedSet orderedSetWithOrderedSet:mutableBoxes];
}

#pragma mark Getters

- (KBCheckBox *)selectedCheckBox {
    KBCheckBox *selected = nil;
    for (KBCheckBox *checkBox in self.checkBoxes) {
        if(checkBox.on){
            selected = checkBox;
            break;
        }
    }
    
    return selected;
}

#pragma mark Setters

- (void)setSelectedCheckBox:(KBCheckBox *)selectedCheckBox {
    if (selectedCheckBox) {
        for (KBCheckBox *checkBox in self.checkBoxes) {
            BOOL shouldBeOn = (checkBox == selectedCheckBox);
            if(checkBox.on != shouldBeOn){
                [checkBox _setOn:shouldBeOn animated:YES notifyGroup:NO];
            }
        }
    } else {
        // Selection is nil
        if(self.mustHaveSelection && [self.checkBoxes count] > 0){
            // We must have a selected checkbox, so re-call this method with the first checkbox
            self.selectedCheckBox = [self.checkBoxes firstObject];
        } else {
            for (KBCheckBox *checkBox in self.checkBoxes) {
                BOOL shouldBeOn = NO;
                if(checkBox.on != shouldBeOn){
                    [checkBox _setOn:shouldBeOn animated:YES notifyGroup:NO];
                }
            }
        }
    }
}

- (void)setMustHaveSelection:(BOOL)mustHaveSelection {
    _mustHaveSelection = mustHaveSelection;
    
    // If it must have a selection and we currently don't, select the first box
    if (mustHaveSelection && !self.selectedCheckBox) {
        self.selectedCheckBox = [self.checkBoxes firstObject];
    }
}

#pragma mark Private methods called by KBCheckBox

- (void)_checkBoxSelectionChanged:(KBCheckBox *)checkBox {
    if ([checkBox on]) {
        // Change selected checkbox to this one
        self.selectedCheckBox = checkBox;
    } else if(checkBox == self.selectedCheckBox) {
        // Selected checkbox was this one, clear it
        self.selectedCheckBox = nil;
    }
}

@end
