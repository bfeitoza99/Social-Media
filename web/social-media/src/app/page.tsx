import Feed from "@/components/feed/feed";
import UserSelector from "@/components/layout/user-selector";


export default function InitialPage() {
  return ( 
    <>
      <UserSelector />
      <Feed />
    </>
  );
}
