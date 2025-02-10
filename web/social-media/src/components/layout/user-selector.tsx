"use client";
import { useUsers } from "@/hooks/useUsers";
import { useUserStore } from "@/store/userStore";
import { useEffect } from "react";

const UserSelector: React.FC = () => {
  const { data: users = [], isLoading } = useUsers();
  const { selectedUser, setSelectedUser } = useUserStore();

  useEffect(() => {
    if (!selectedUser && users?.length > 0) {
      setSelectedUser(users[0]);
    }
  }, [users, selectedUser, setSelectedUser]);

  if (isLoading) return <p className="text-white">Loading...</p>;
  if (!users || users.length === 0) return null;

  return (
    <div className="border-b border-neutral-800 p-5">
      <div className="flex justify-center items-center w-full space-x-6">
        <h1 className="text-white text-xl ">Select User:</h1>
        <div className="relative">
          <select
            className="bg-neutral-800 text-white border border-neutral-700 rounded px-3 py-2"
            value={selectedUser?.id ?? ""}
            onChange={(e) => {
              const user = users.find((u) => u.id === parseInt(e.target.value));
              if (user) setSelectedUser(user);
            }}
          >
            {users.map((user) => (
              <option key={user.id} value={user.id}>
                {user.nickname}
              </option>
            ))}
          </select>
        </div>
      </div>
    </div>
  );
};

export default UserSelector;
