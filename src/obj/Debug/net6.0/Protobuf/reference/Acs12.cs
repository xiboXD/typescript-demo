// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protobuf/reference/acs12.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace AElf.Standards.ACS12 {

  /// <summary>Holder for reflection information generated from Protobuf/reference/acs12.proto</summary>
  internal static partial class Acs12Reflection {

    #region Descriptor
    /// <summary>File descriptor for Protobuf/reference/acs12.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static Acs12Reflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Ch5Qcm90b2J1Zi9yZWZlcmVuY2UvYWNzMTIucHJvdG8SBWFjczEyGhJhZWxm",
            "L29wdGlvbnMucHJvdG8aG2dvb2dsZS9wcm90b2J1Zi9lbXB0eS5wcm90bxoe",
            "Z29vZ2xlL3Byb3RvYnVmL3dyYXBwZXJzLnByb3RvGg9hZWxmL2NvcmUucHJv",
            "dG8iXgoWVXNlckNvbnRyYWN0TWV0aG9kRmVlcxIqCgRmZWVzGAIgAygLMhwu",
            "YWNzMTIuVXNlckNvbnRyYWN0TWV0aG9kRmVlEhgKEGlzX3NpemVfZmVlX2Zy",
            "ZWUYAyABKAgiOgoVVXNlckNvbnRyYWN0TWV0aG9kRmVlEg4KBnN5bWJvbBgB",
            "IAEoCRIRCgliYXNpY19mZWUYAiABKAMyDgoMVXNlckNvbnRyYWN0QiGqAhRB",
            "RWxmLlN0YW5kYXJkcy5BQ1MxMoqS9AEFYWNzMTJQAFABUAJiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::AElf.OptionsReflection.Descriptor, global::Google.Protobuf.WellKnownTypes.EmptyReflection.Descriptor, global::Google.Protobuf.WellKnownTypes.WrappersReflection.Descriptor, global::AElf.Types.CoreReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::AElf.Standards.ACS12.UserContractMethodFees), global::AElf.Standards.ACS12.UserContractMethodFees.Parser, new[]{ "Fees", "IsSizeFeeFree" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::AElf.Standards.ACS12.UserContractMethodFee), global::AElf.Standards.ACS12.UserContractMethodFee.Parser, new[]{ "Symbol", "BasicFee" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  ///Specified method fee for user contract.
  /// </summary>
  internal sealed partial class UserContractMethodFees : pb::IMessage<UserContractMethodFees>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<UserContractMethodFees> _parser = new pb::MessageParser<UserContractMethodFees>(() => new UserContractMethodFees());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<UserContractMethodFees> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::AElf.Standards.ACS12.Acs12Reflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public UserContractMethodFees() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public UserContractMethodFees(UserContractMethodFees other) : this() {
      fees_ = other.fees_.Clone();
      isSizeFeeFree_ = other.isSizeFeeFree_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public UserContractMethodFees Clone() {
      return new UserContractMethodFees(this);
    }

    /// <summary>Field number for the "fees" field.</summary>
    public const int FeesFieldNumber = 2;
    private static readonly pb::FieldCodec<global::AElf.Standards.ACS12.UserContractMethodFee> _repeated_fees_codec
        = pb::FieldCodec.ForMessage(18, global::AElf.Standards.ACS12.UserContractMethodFee.Parser);
    private readonly pbc::RepeatedField<global::AElf.Standards.ACS12.UserContractMethodFee> fees_ = new pbc::RepeatedField<global::AElf.Standards.ACS12.UserContractMethodFee>();
    /// <summary>
    /// List of fees to be charged.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<global::AElf.Standards.ACS12.UserContractMethodFee> Fees {
      get { return fees_; }
    }

    /// <summary>Field number for the "is_size_fee_free" field.</summary>
    public const int IsSizeFeeFreeFieldNumber = 3;
    private bool isSizeFeeFree_;
    /// <summary>
    /// Optional based on the implementation of SetConfiguration method.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool IsSizeFeeFree {
      get { return isSizeFeeFree_; }
      set {
        isSizeFeeFree_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as UserContractMethodFees);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(UserContractMethodFees other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!fees_.Equals(other.fees_)) return false;
      if (IsSizeFeeFree != other.IsSizeFeeFree) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= fees_.GetHashCode();
      if (IsSizeFeeFree != false) hash ^= IsSizeFeeFree.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      fees_.WriteTo(output, _repeated_fees_codec);
      if (IsSizeFeeFree != false) {
        output.WriteRawTag(24);
        output.WriteBool(IsSizeFeeFree);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      fees_.WriteTo(ref output, _repeated_fees_codec);
      if (IsSizeFeeFree != false) {
        output.WriteRawTag(24);
        output.WriteBool(IsSizeFeeFree);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      size += fees_.CalculateSize(_repeated_fees_codec);
      if (IsSizeFeeFree != false) {
        size += 1 + 1;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(UserContractMethodFees other) {
      if (other == null) {
        return;
      }
      fees_.Add(other.fees_);
      if (other.IsSizeFeeFree != false) {
        IsSizeFeeFree = other.IsSizeFeeFree;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 18: {
            fees_.AddEntriesFrom(input, _repeated_fees_codec);
            break;
          }
          case 24: {
            IsSizeFeeFree = input.ReadBool();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 18: {
            fees_.AddEntriesFrom(ref input, _repeated_fees_codec);
            break;
          }
          case 24: {
            IsSizeFeeFree = input.ReadBool();
            break;
          }
        }
      }
    }
    #endif

  }

  internal sealed partial class UserContractMethodFee : pb::IMessage<UserContractMethodFee>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<UserContractMethodFee> _parser = new pb::MessageParser<UserContractMethodFee>(() => new UserContractMethodFee());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<UserContractMethodFee> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::AElf.Standards.ACS12.Acs12Reflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public UserContractMethodFee() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public UserContractMethodFee(UserContractMethodFee other) : this() {
      symbol_ = other.symbol_;
      basicFee_ = other.basicFee_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public UserContractMethodFee Clone() {
      return new UserContractMethodFee(this);
    }

    /// <summary>Field number for the "symbol" field.</summary>
    public const int SymbolFieldNumber = 1;
    private string symbol_ = "";
    /// <summary>
    /// The token symbol of the method fee.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Symbol {
      get { return symbol_; }
      set {
        symbol_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "basic_fee" field.</summary>
    public const int BasicFeeFieldNumber = 2;
    private long basicFee_;
    /// <summary>
    /// The amount of fees to be charged.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public long BasicFee {
      get { return basicFee_; }
      set {
        basicFee_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as UserContractMethodFee);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(UserContractMethodFee other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Symbol != other.Symbol) return false;
      if (BasicFee != other.BasicFee) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (Symbol.Length != 0) hash ^= Symbol.GetHashCode();
      if (BasicFee != 0L) hash ^= BasicFee.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (Symbol.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Symbol);
      }
      if (BasicFee != 0L) {
        output.WriteRawTag(16);
        output.WriteInt64(BasicFee);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (Symbol.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Symbol);
      }
      if (BasicFee != 0L) {
        output.WriteRawTag(16);
        output.WriteInt64(BasicFee);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (Symbol.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Symbol);
      }
      if (BasicFee != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(BasicFee);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(UserContractMethodFee other) {
      if (other == null) {
        return;
      }
      if (other.Symbol.Length != 0) {
        Symbol = other.Symbol;
      }
      if (other.BasicFee != 0L) {
        BasicFee = other.BasicFee;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Symbol = input.ReadString();
            break;
          }
          case 16: {
            BasicFee = input.ReadInt64();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            Symbol = input.ReadString();
            break;
          }
          case 16: {
            BasicFee = input.ReadInt64();
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
