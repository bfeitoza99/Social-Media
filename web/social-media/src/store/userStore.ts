
import { User } from "@/type/api/user";
import { create } from "zustand";

interface UserStore {
  selectedUser: User | null;
  setSelectedUser: (user: User) => void;
}

export const useUserStore = create<UserStore>((set) => ({
  selectedUser: null,
  setSelectedUser: (user) => set({ selectedUser: user }),
}));
