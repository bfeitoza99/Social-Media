import { create } from "zustand";

interface PostStoreState {
  orderBy: "latest" | "trending";
  keyword: string;
  setOrderBy: (orderBy: "latest" | "trending") => void;
  setKeyword: (keyword: string) => void;
}

export const useFilterPostStore = create<PostStoreState>((set) => ({
  orderBy: "latest", 
  keyword: "",
  setOrderBy: (orderBy) => set({ orderBy }),
  setKeyword: (keyword) => set({ keyword }),
}));
