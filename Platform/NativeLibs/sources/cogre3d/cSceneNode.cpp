#include "cOgre.h"

/**
 * Method: SceneNode::attachObject
 */
INV_EXPORT void
INV_CALL scenenode_attach_object(InvHandle self, InvHandle obj)
{
	asSceneNode(self)->attachObject(
				castHandle<Ogre::MovableObject>(obj));
}

/**
 * Method: SceneNode::numAttachedObjects
 */
INV_EXPORT _ushort
INV_CALL scenenode_num_attached_objects(InvHandle self)
{
	return asSceneNode(self)->numAttachedObjects();
}

/**
 * Method: SceneNode::getAttachedObject
 */
INV_EXPORT InvHandle
INV_CALL scenenode_get_attached_object_m1(InvHandle self, _ushort index)
{
	return createReference<Ogre::MovableObject>(
				asSceneNode(self)->getAttachedObject(index));
}

/**
 * Method: SceneNode::getAttachedObject
 */
INV_EXPORT InvHandle
INV_CALL scenenode_get_attached_object_m2(InvHandle self, _string name)
{
	return createReference<Ogre::MovableObject>(
				asSceneNode(self)->getAttachedObject(name));
}

/**
 * Method: SceneNode::detachObject
 */
INV_EXPORT InvHandle
INV_CALL scenenode_detach_object_m1(InvHandle self, _ushort index)
{
	return createReference<Ogre::MovableObject>(
				asSceneNode(self)->detachObject(index));
}

/**
 * Method: SceneNode::detachObject
 */
INV_EXPORT void
INV_CALL scenenode_detach_object_m2(InvHandle self, InvHandle movableObject)
{
	asSceneNode(self)->detachObject(
				asMovableObject(movableObject));
}

/**
 * Method: SceneNode::detachObject
 */
INV_EXPORT InvHandle
INV_CALL scenenode_detach_object_m3(InvHandle self, _string name)
{
	return createReference<Ogre::MovableObject>(
				asSceneNode(self)->detachObject(name));
}

/**
 * Method: SceneNode::createChildSceneNode
 */
INV_EXPORT InvHandle
INV_CALL scenenode_create_child_scene_node_m1(InvHandle self)
{
	return createReference<Ogre::SceneNode>(
				asSceneNode(self)->createChildSceneNode());
}

/**
 * Method: SceneNode::detachAllObjects
 */
INV_EXPORT void
INV_CALL scenenode_detach_all_objects(InvHandle self)
{
	asSceneNode(self)->detachAllObjects();
}

/**
 * Method: SceneNode::createChildSceneNode
 */
INV_EXPORT InvHandle
INV_CALL scenenode_create_child_scene_node_m2(InvHandle self, Vector3 translate)
{
	return createReference<Ogre::SceneNode>(
				asSceneNode(self)->createChildSceneNode(
					Ogre::Vector3(translate.x, translate.y, translate.z)));
}

/**
 * Method: SceneNode::createChildSceneNode
 */
INV_EXPORT InvHandle
INV_CALL scenenode_create_child_scene_node_m3(InvHandle self, Vector3 translate, Quaternion rotate)
{
	return createReference<Ogre::SceneNode>(
				asSceneNode(self)->createChildSceneNode(
					Ogre::Vector3(translate.x, translate.y, translate.z),
					Ogre::Quaternion(rotate.w, rotate.x, rotate.y, rotate.z)));
}

/**
 * Method: SceneNode::createChildSceneNode
 */
INV_EXPORT InvHandle
INV_CALL scenenode_create_child_scene_node_m4(InvHandle self, _string name)
{
	return createReference<Ogre::SceneNode>(
				asSceneNode(self)->createChildSceneNode(name));
}

/**
 * Method: SceneNode::createChildSceneNode
 */
INV_EXPORT InvHandle
INV_CALL scenenode_create_child_scene_node_m5(InvHandle self, _string name, Vector3 translate)
{
	return createReference<Ogre::SceneNode>(
				asSceneNode(self)->createChildSceneNode(
					name,
					Ogre::Vector3(translate.x, translate.y, translate.z)));
}

/**
 * Method: SceneNode::createChildSceneNode
 */
INV_EXPORT InvHandle
INV_CALL scenenode_create_child_scene_node_m6(InvHandle self, _string name, Vector3 translate, Quaternion rotate)
{
	return createReference<Ogre::SceneNode>(
				asSceneNode(self)->createChildSceneNode(
					name,
					Ogre::Vector3(translate.x, translate.y, translate.z),
					Ogre::Quaternion(rotate.w, rotate.x, rotate.y, rotate.z)));
}

INV_EXPORT void
INV_CALL scenenode_set_position(InvHandle self, Vector3 value)
{
	asSceneNode(self)->setPosition(
				vector3_convert_to_ogre(value));
}

INV_EXPORT Vector3
INV_CALL scenenode_get_position(InvHandle self)
{
	return vector3_convert_from_ogre(
				asSceneNode(self)->getPosition());
}

INV_EXPORT void
INV_CALL scenenode_set_scale(InvHandle self, Vector3 scale)
{
	asSceneNode(self)->setScale(scale.x, scale.y, scale.z);
}

INV_EXPORT Vector3
INV_CALL scenenode_get_scale(InvHandle self)
{
	return vector3_convert_from_ogre(
				asSceneNode(self)->getScale());
}

INV_EXPORT Quaternion
INV_CALL scenenode_get_orientation(InvHandle self)
{
	Ogre::Quaternion q = asSceneNode(self)->getOrientation();

	Quaternion result;
	result.x = q.x;
	result.y = q.y;
	result.z = q.z;
	result.w = q.w;

	return result;
}

INV_EXPORT void
INV_CALL scenenode_set_orientation(InvHandle self, Quaternion orientation)
{
	asSceneNode(self)->setOrientation(Ogre::Quaternion(orientation.w, orientation.x, orientation.y, orientation.z));
}
