interface AvatarProps {
    src: string;
    alt?: string;
    size?: number;
  }
  
  const Avatar: React.FC<AvatarProps> = ({ src, alt = "User Avatar", size = 50 }) => {
    return (
      <img
        src={src}
        alt={alt}
        className="rounded-full"
        style={{ width: `${size}px`, height: `${size}px` }}
      />
    );
  };
  
  export default Avatar;
  