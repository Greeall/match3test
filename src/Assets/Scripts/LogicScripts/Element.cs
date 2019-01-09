using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element {

  public int type;

  public Element(int _type)
  {
	  type = _type;
  }

  public override string ToString() 
  {
    return type.ToString();
  }

  public override bool Equals(object obj) {
    var e2 = obj as Element;

    if (e2 == null)
      return false;

    return this.type == e2.type;
  }

  public static bool operator ==(Element e1, Element e2) 
  {
    if (object.ReferenceEquals(e1, null))
    {
      return object.ReferenceEquals(e2, null);
    }

    return e1.Equals(e2);
  }

  public static bool operator !=(Element e1, Element e2) {
    if (object.ReferenceEquals(e1, null))
    {
      return !object.ReferenceEquals(e2, null);
    }

    return !e1.Equals(e2);
  }
}


