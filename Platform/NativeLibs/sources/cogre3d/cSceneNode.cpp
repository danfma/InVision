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
