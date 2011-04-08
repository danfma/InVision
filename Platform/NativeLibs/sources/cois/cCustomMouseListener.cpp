#include "cCustomMouseListener.h"

using namespace invision::ois;

__export HCustomMouseListener __entry ois_custommouselistener_new(
	MouseMoveEventHandler mouseMove,
	MouseClickEventHandler mousePressed,
	MouseClickEventHandler mouseReleased)
{
	return new CustomMouseListener(mouseMove, mousePressed, mouseReleased);
}

__export void __entry ois_custommouselistener_delete(HCustomMouseListener self)
{
	delete asCustomMouseListener(self);
}
