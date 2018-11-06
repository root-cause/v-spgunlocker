# Addon Examples
This directory contains files that show you how to add new weapons to the mod, put the files into `your GTA V folder/scripts/gunlockers_addons`.

# Tutorial
XML files are used to add new weapons. Go to `your GTA V folder/scripts/gunlockers_addons`, if `gunlockers_addons` doesn't exist, feel free to create it.

Then create a file with the `.xml` extension (such as `MyContentPack.xml`) and add your data.

File content:
```xml
<?xml version="1.0" encoding="utf-16"?>
<Addon xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Weapons>
    <AddonWeapon> <!-- Start of one addon weapon -->
      <WeaponName>weapon_dummy_pistol</WeaponName> <!-- Hash key of the weapon, used with Game.GenerateHash(). -->
      <DisplayName>Dummy Pistol Thing</DisplayName> <!-- The human readable name of the weapon, will be used in the menus. -->
      <SlotType>Small</SlotType> <!-- Slot type of the weapon. Available: Small, Big, Throwable -->
      
      <!-- Add ALL components of the weapon. -->
      <AvailableComponents>
        <string>COMPONENT_EXTENDED_MAG</string>
        <string>COMPONENT_LASER_SIGHT</string>
        <string>COMPONENT_NAME_THAT_CHANGES_WEAPON_OBJECT</string>
      </AvailableComponents>
      
      <!-- If the weapon doesn't have any components, just write <AvailableComponents /> instead. -->
      
      <!-- Some weapon objects might not fit their place properly, you can use these to make them fit better. -->
      <AttachmentPositionOffset>
        <X>0</X>
        <Y>0</Y>
        <Z>0</Z>
      </AttachmentPositionOffset>
      
      <AttachmentRotationOffset>
        <X>0</X>
        <Y>0</Y>
        <Z>0</Z>
      </AttachmentRotationOffset>
    </AddonWeapon> <!-- End of one addon weapon -->
    
    <!-- You can place the AddonWeapon element inside Weapons node as many times as you want and edit the values for new weapons. -->
  </Weapons>
  
  <!-- If any of the weapons have components that replace the weapon object (like the Yusuf Amir Luxury Finish), write them here. -->
  <LuxuryComponents>
    <string>COMPONENT_NAME_THAT_CHANGES_WEAPON_OBJECT</string>
    <string>Another component...</string>
  </LuxuryComponents>
  
  <!-- If none of the weapons have components that replace the weapon object, just write <LuxuryComponents /> instead. -->
</Addon>
```
