#ifndef __INVISIONNATIVE_OIS_H__
#define __INVISIONNATIVE_OIS_H__

#include <InvisionHandle.h>

extern "C"
{
	struct EventArgDescriptor;
	struct ComponentDescriptor;
	struct Vector3Descriptor;
	struct ButtonDescriptor;
	struct AxisDescriptor;
	struct NameValueItem;
	struct DeviceTypeItem;
	
	/**
	 * Type EventArgDescriptor
	 */
	struct EventArgDescriptor
	{
		InvHandle self;
	};
	
	/**
	 * Type ComponentDescriptor
	 */
	struct ComponentDescriptor
	{
		InvHandle handle;
		_int* ctype;
	};
	
	/**
	 * Type Vector3Descriptor
	 */
	struct Vector3Descriptor
	{
		ComponentDescriptor base;
		_float* x;
		_float* y;
		_float* z;
	};
	
	/**
	 * Type ButtonDescriptor
	 */
	struct ButtonDescriptor
	{
		ComponentDescriptor base;
		_bool* pushed;
	};
	
	/**
	 * Type AxisDescriptor
	 */
	struct AxisDescriptor
	{
		ComponentDescriptor base;
		_int* abs;
		_int* rel;
		_bool* absOnly;
	};
	
	/**
	 * Type NameValueItem
	 */
	struct NameValueItem
	{
		_string Name;
		_string Value;
	};
	
	/**
	 * Type DeviceTypeItem
	 */
	struct DeviceTypeItem
	{
		_int DeviceType;
		_string Name;
	};
	
	
	/**
	 * Method: Component::Component
	 */
	INV_EXPORT ComponentDescriptor
	INV_CALL new_component();
	
	/**
	 * Method: Component::Component
	 */
	INV_EXPORT ComponentDescriptor
	INV_CALL new_component_by_ctype(_int ctype);
	
	/**
	 * Method: Component::~Component
	 */
	INV_EXPORT void
	INV_CALL delete_component(InvHandle self);
	
	/**
	 * Method: Button::Button
	 */
	INV_EXPORT ButtonDescriptor
	INV_CALL new_button();
	
	/**
	 * Method: Button::Button
	 */
	INV_EXPORT ButtonDescriptor
	INV_CALL new_button_by_pushed(_bool pushed);
	
	/**
	 * Method: Axis::Axis
	 */
	INV_EXPORT AxisDescriptor
	INV_CALL new_axis();
	
	/**
	 * Method: Vector3::Vector3
	 */
	INV_EXPORT Vector3Descriptor
	INV_CALL new_vector3();
	
	/**
	 * Method: Vector3::Vector3
	 */
	INV_EXPORT Vector3Descriptor
	INV_CALL new_vector3_by_x_y_z(_float x, _float y, _float z);
	
	/**
	 * Method: EventArg::EventArg
	 */
	INV_EXPORT EventArgDescriptor
	INV_CALL new_eventarg_by_devicehandle(InvHandle deviceHandle);
	
	/**
	 * Method: EventArg::~EventArg
	 */
	INV_EXPORT void
	INV_CALL delete_eventarg(InvHandle self);
	
	/**
	 * Method: EventArg::getDevice
	 */
	INV_EXPORT InvHandle
	INV_CALL eventarg_get_device(InvHandle self);
	
	/**
	 * Method: Object::~Object
	 */
	INV_EXPORT void
	INV_CALL delete_object(InvHandle self);
	
	/**
	 * Method: Object::getType
	 */
	INV_EXPORT _int
	INV_CALL object_get_type(InvHandle self);
	
	/**
	 * Method: Object::getVendor
	 */
	INV_EXPORT _string
	INV_CALL object_get_vendor(InvHandle self);
	
	/**
	 * Method: Object::isBuffered
	 */
	INV_EXPORT _bool
	INV_CALL object_is_buffered(InvHandle self);
	
	/**
	 * Method: Object::setBuffered
	 */
	INV_EXPORT void
	INV_CALL object_set_buffered(InvHandle self, _bool value);
	
	/**
	 * Method: Object::getCreator
	 */
	INV_EXPORT InvHandle
	INV_CALL object_get_creator(InvHandle self);
	
	/**
	 * Method: Object::capture
	 */
	INV_EXPORT void
	INV_CALL object_capture(InvHandle self);
	
	/**
	 * Method: Object::getID
	 */
	INV_EXPORT _int
	INV_CALL object_get_id(InvHandle self);
	
	/**
	 * Method: Object::queryInterface
	 */
	INV_EXPORT InvHandle
	INV_CALL object_query_interface(InvHandle self, _int interfaceType);
	
	/**
	 * Method: Interface::~Interface
	 */
	INV_EXPORT void
	INV_CALL delete_interface(InvHandle self);
	
	/**
	 * Method: FactoryCreator::~FactoryCreator
	 */
	INV_EXPORT void
	INV_CALL delete_factorycreator(InvHandle self);
	
	/**
	 * Method: FactoryCreator::freeDeviceList
	 */
	INV_EXPORT _any
	INV_CALL factorycreator_free_device_list(InvHandle self);
	
	/**
	 * Method: FactoryCreator::totalDevices
	 */
	INV_EXPORT _int
	INV_CALL factorycreator_total_devices(InvHandle self, _int deviceType);
	
	/**
	 * Method: FactoryCreator::freeDevices
	 */
	INV_EXPORT _int
	INV_CALL factorycreator_free_devices(InvHandle self, _int deviceType);
	
	/**
	 * Method: FactoryCreator::vendorExist
	 */
	INV_EXPORT _bool
	INV_CALL factorycreator_vendor_exist1(InvHandle self, _int deviceType);
	
	/**
	 * Method: FactoryCreator::vendorExist
	 */
	INV_EXPORT _bool
	INV_CALL factorycreator_vendor_exist2(InvHandle self, _int deviceType, _wstring vendor);
	
	/**
	 * Method: FactoryCreator::createObject
	 */
	INV_EXPORT InvHandle
	INV_CALL factorycreator_create_object1(InvHandle self, _int deviceType, _bool bufferMode);
	
	/**
	 * Method: FactoryCreator::createObject
	 */
	INV_EXPORT InvHandle
	INV_CALL factorycreator_create_object2(InvHandle self, _int deviceType, _bool bufferMode, _string vendor);
	
	/**
	 * Method: FactoryCreator::destroyObject
	 */
	INV_EXPORT void
	INV_CALL factorycreator_destroy_object(InvHandle self, InvHandle deviceHandle);
	
	/**
	 * Method: FactoryCreator::getVersionNumber
	 */
	INV_EXPORT _uint
	INV_CALL factorycreator_get_version_number();
	
	/**
	 * Method: FactoryCreator::createInputSystem
	 */
	INV_EXPORT InvHandle
	INV_CALL factorycreator_create_input_system1(_int winHandle);
	
	/**
	 * Method: FactoryCreator::createInputSystem
	 */
	INV_EXPORT InvHandle
	INV_CALL factorycreator_create_input_system2(NameValueItem parameters, _int paramCount);
	
	/**
	 * Method: FactoryCreator::destroyInputSystem
	 */
	INV_EXPORT void
	INV_CALL factorycreator_destroy_input_system(InvHandle handle);
	
	/**
	 * Method: FactoryCreator::getVersionName
	 */
	INV_EXPORT _string
	INV_CALL factorycreator_get_version_name(InvHandle self);
	
	/**
	 * Method: FactoryCreator::inputSystemName
	 */
	INV_EXPORT _string
	INV_CALL factorycreator_input_system_name(InvHandle self);
	
	/**
	 * Method: FactoryCreator::getNumberOfDevices
	 */
	INV_EXPORT _int
	INV_CALL factorycreator_get_number_of_devices(InvHandle self, _int deviceType);
	
	/**
	 * Method: FactoryCreator::createInputObject
	 */
	INV_EXPORT InvHandle
	INV_CALL factorycreator_create_input_object1(InvHandle self, _int deviceType, _bool bufferMode);
	
	/**
	 * Method: FactoryCreator::createInputObject
	 */
	INV_EXPORT InvHandle
	INV_CALL factorycreator_create_input_object2(InvHandle self, _int deviceType, _bool bufferMode, _string vendor);
	
	/**
	 * Method: FactoryCreator::destroyInputObject
	 */
	INV_EXPORT void
	INV_CALL factorycreator_destroy_input_object(InvHandle self, InvHandle deviceHandle);
	
	/**
	 * Method: FactoryCreator::addFactoryCreator
	 */
	INV_EXPORT void
	INV_CALL factorycreator_add_factory_creator(InvHandle self, InvHandle factoryHandle);
	
	/**
	 * Method: FactoryCreator::removeFactoryCreator
	 */
	INV_EXPORT void
	INV_CALL factorycreator_remove_factory_creator(InvHandle self, InvHandle factoryHandle);
	
	/**
	 * Method: FactoryCreator::enableAddOnFactory
	 */
	INV_EXPORT void
	INV_CALL factorycreator_enable_add_on_factory(InvHandle self, _int factory);
	
}

#endif // __INVISIONNATIVE_OIS_H__
