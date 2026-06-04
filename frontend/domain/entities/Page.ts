import { Entity, PrimaryGeneratedColumn, Column, ManyToOne, OneToMany, JoinColumn } from 'typeorm';
import { User } from './User';
import { Workspace } from './Workspace';

@Entity('Page')
export class Page {
  @PrimaryGeneratedColumn({ type: 'bigint' })
  id: string;

  @Column({ type: 'text' })
  title: string;

  @Column({ type: 'text', nullable: true })
  content: string;

  @Column({ type: 'timestamp' })
  create_at: Date;

  @Column({ type: 'timestamp' })
  update_at: Date;

  @Column({ type: 'bigint' })
  created_by: string;

  @Column({ type: 'boolean' })
  is_deleted: boolean;

  @Column({ type: 'bigint', nullable: true })
  parent_page_id: string;

  @Column({ type: 'bigint' })
  Workspace_id: string;

  @ManyToOne(() => User, (user) => user.createdPages)
  @JoinColumn({ name: 'created_by' })
  creator: User;

  @ManyToOne(() => Workspace, (workspace) => workspace.pages)
  @JoinColumn({ name: 'Workspace_id' })
  workspace: Workspace;

  @ManyToOne(() => Page, (page) => page.subPages)
  @JoinColumn({ name: 'parent_page_id' })
  parentPage: Page;

  @OneToMany(() => Page, (page) => page.parentPage)
  subPages: Page[];
}
