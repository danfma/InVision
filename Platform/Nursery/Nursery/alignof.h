// alignof library

// Copyright (C) 2003 Martin Buchholz
//
// Permission to copy, use, sell and distribute this software is granted
// provided this copyright notice appears in all copies.
// Permission to modify the code and to distribute modified code is granted
// provided this copyright notice appears in all copies, and a notice
// that the code was modified is included with the copyright notice.
//
// This software is provided "as is" without express or implied warranty,
// and with no claim as to its suitability for any purpose.
//

// ----------------------------------------------------------------
// This code is known to work with the following compilers:
// Linux x86 g++ 2.95
// Linux x86 g++ 3.2.1
// Linux x86 g++ 3.3 20030122 pre-release
// Linux x86 g++ 3.4 20030122 pre-release
// Linux x86 Intel compiler Version 7.0
// Windows x86 MS Visual C++ .NET Version 13.00

// To work with MS Visual C++, we avoid partial template specialization.
// ----------------------------------------------------------------

#ifndef ALIGNOF_HPP_INCLUDED_
#define ALIGNOF_HPP_INCLUDED_

#if defined (__cplusplus)

namespace Alignment
{
  // Implementing alignof:
  // We compute alignof using two separate algorithms, then take their min.

  namespace ffs
  {
    // alignof (T) must be a power of two which is a factor of sizeof (T).
    template <typename T>
    struct alignof
    {
      // Most common programmer interview question!
      enum { s = sizeof (T), value = s ^ (s & (s - 1)) };
    };
  }

  namespace QuantumJump
  {
    // Put T in a struct, keep adding chars until a "quantum jump" in
    // the size occurs.
    template <typename T> struct alignof;

    template <int size_diff>
    struct helper
    {
      template <typename T> struct Val { enum { value = size_diff }; };
    };

    template <>
    struct helper<0>
    {
      template <typename T> struct Val { enum { value = alignof<T>::value }; };
    };

    template <typename T>
    struct alignof
    {
      struct Big { T x; char c; };

      enum { diff = sizeof (Big) - sizeof (T),
	     value = helper<diff>::template Val<Big>::value };
    };

  } // QuantumJump

  template <typename T>
  struct alignof
  {
    enum { x = QuantumJump::alignof<T>::value,
	   y = ffs::alignof<T>::value,
	   value = x < y ? x : y };
  };

  // ----------------------------------------------------------------

  namespace POD
  {
    // Implementing alignpod:
    // We look for a POD type with the same alignment as a given C++ type T.
    // We first check a list of fundamental types.
    // In the unlikely event that that fails,
    // we check pointers to those types and structs containing those types.

    template <typename T, typename U>
    struct equally_aligned
    {
      enum { value = ((int) alignof<T>::value ==
		      (int) alignof<U>::value) };
    };

    enum { TYPES_COUNT = 10 };

    template <int n> struct types;

    struct Unknown;

    template <bool POINTERIFY, bool STRUCTIFY>
    struct types_helper
    {
      // This definition should be unnecessary, but makes MSVC happy
      template <int index> struct Val { typedef char Type; };
    };

    template <>
    struct types_helper<true, false>
    {
      template <int index>
      struct Val
      {
	typedef typename types<index - (1 * TYPES_COUNT)>::Type BaseType;
	typedef BaseType* Type;
      };
    };

    template <>
    struct types_helper<false, true>
    {
      template <int index>
      struct Val
      {
	typedef typename types<index - (2 * TYPES_COUNT)>::Type BaseType;
	struct Type { BaseType t; };
      };
    };

    template <int n>
    struct types
    {
      enum { pointerify = ((n >= 1 * TYPES_COUNT) && (n < 2 * TYPES_COUNT)) };
      enum { structify  = ((n >= 2 * TYPES_COUNT) && (n < 3 * TYPES_COUNT)) };

      typedef typename
      types_helper<pointerify, structify>::template Val<n>::Type
      Type;
    };
    template <> struct types<0> { typedef char          Type; };
    template <> struct types<1> { typedef short         Type; };
    template <> struct types<2> { typedef int           Type; };
    template <> struct types<3> { typedef long          Type; };
    template <> struct types<4> { typedef float         Type; };
    template <> struct types<5> { typedef double        Type; };
    template <> struct types<6> { typedef long double   Type; };
    template <> struct types<7> { typedef void*         Type; };
    template <> struct types<8> { typedef void (*Type) (void); };
    template <> struct types<9> { typedef Unknown (Unknown::*Type) (Unknown);};

    namespace LinearSearch
    {
      template <bool EQUALLY_ALIGNED> struct helper;

      template <>
      struct helper<true>
      {
	template <typename T, int index>
	struct Val
	{
	  typedef typename types<index>::Type Type;
	};
      };

      template <typename T, int index>
      struct alignpod
      {
	typedef typename types<index>::Type Candidate;
	enum { EQUALLY_ALIGNED = equally_aligned<T,Candidate>::value };

	typedef typename
	helper<EQUALLY_ALIGNED>::template Val<T,index>::Type
	Type;
      };

      template <>
      struct helper<false>
      {
	template <typename T, int index>
	struct Val
	{
	  typedef typename alignpod<T, index+1>::Type Type;
	};
      };

    } // LinearSearch

  } // POD

  template <typename T>
  struct alignpod
  {
    typedef typename POD::LinearSearch::alignpod<T,0>::Type Type;
  };
} // Alignment

#endif /* C++ */

/* gcc has an extension that gives us exactly what we want.
   We would use this in production code.

  #if defined (__GNUC__) && (__GNUC__ >= 2)
  #define ALIGNOF(type) __alignof__ (type)
*/

/* The following works with all known C++ compilers for POD types.
   It doesn't have the "inside out" declaration bug C does.
   But C++ forbids the use of offsetof with non-POD types.

  template<typename T> struct alignment_trick { char c; T member; };
  #define ALIGNOF(type) offsetof (alignment_trick<type>, member)
*/


/* ALIGNOF (type)
   Return alignment of TYPE. */
#if defined (__cplusplus) /* C++ */
#define ALIGNOF(type) Alignment::alignof<type>::value
#else /* C */
/* The following is mostly portable, except that:
   - It doesn't work for inside out declarations like void (*) (void).
     (so just call ALIGNOF with a typedef'ed name)
   - It doesn't work with C++, not even with fundamental types.
     The C++ committee has decreed:
     "Types must be declared in declarations, not in expressions." */
#define ALIGNOF(type) offsetof (struct { char c; type member; }, member)
#endif


/* ALIGNOF_POD_TYPE (type)
   Return a POD (Plain Ol' Data) type with the same alignment as TYPE. */
#if defined (__cplusplus) /* C++ */
#define ALIGN_POD_TYPE(type) Alignment::alignpod<type>::Type
#else
#define ALIGN_POD_TYPE(type) type
#endif

#endif // Recursive inclusion guard
