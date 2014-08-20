using System;

namespace SpecAid.XmlAid
{
    public class XmlAidView : IEquatable<XmlAidView>
    {
        public string NodeName { get; set; }
        public object Value { get; set; }

        public int Level {get;set;}

        public string FullPath
        {
            get
            {
                if (Level == 0)
                    return this.NodeName;
                return string.Format("{0}{1}", new String(IndentChar, this.Level), this.NodeName);
            }
        }

        public bool Equals(XmlAidView other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Level == other.Level && string.Equals(NodeName, other.NodeName) && Equals(Value, other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((XmlAidView) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Level;
                hashCode = (hashCode*397) ^ (NodeName != null ? NodeName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Value != null ? Value.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(XmlAidView left, XmlAidView right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(XmlAidView left, XmlAidView right)
        {
            return !Equals(left, right);
        }

        public static char AttributePrefix
        {
            get { return '+'; }
        }

        public static char IndentChar
        {
            get { return '.'; }
        }

        public override string ToString()
        {
            return string.Format("{0}={1}", this.FullPath, this.Value);
        }
    } 


}
